// This example demonstrates how to use Vault's format-preserving encryption (FPE)
// to encrypt and decrypt text without changing its length.

using System.Globalization;
using System.Text.Json;
using PangeaCyber.Net;
using PangeaCyber.Net.Vault;
using PangeaCyber.Net.Vault.Models;
using PangeaCyber.Net.Vault.Requests;

// Set up a Pangea Vault client.
var token = Config.LoadEnvironmentVariable("PANGEA_VAULT_TOKEN");
var domain = Config.LoadEnvironmentVariable("PANGEA_DOMAIN");
var config = new Config(token, domain);
var vault = new VaultClient.Builder(config).Build();

// Plain text that we'll encrypt.
var plainText = "123-4567-8901";

// Optional tweak string.
var tweak = "MTIzMTIzMT==";

// Generate an encryption key.
var time = DateTimeOffset.UtcNow.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
var generated = await vault.SymmetricGenerate(
    new SymmetricGenerateRequest(
        SymmetricAlgorithm.AES256_FF3_1,
        KeyPurpose.FPE,
        $"dotnet-fpe-example-{time}"
    )
);
var keyId = generated.Result.ID;

// Encrypt the plain text.
var encrypted = await vault.EncryptTransform(new EncryptTransformRequest
{
    ID = keyId,
    PlainText = plainText,
    Tweak = tweak,
    Alphabet = TransformAlphabet.NUMERIC
});
var encryptedText = encrypted.Result.CipherText;
Console.WriteLine($"Plain text: {plainText}. Encrypted text: {encryptedText}.");

// Decrypt the result to get back the text we started with.
var decrypted = await vault.DecryptTransform(new DecryptTransformRequest
{
    ID = keyId,
    CipherText = encryptedText,
    Tweak = tweak,
    Alphabet = TransformAlphabet.NUMERIC
});
var decryptedText = decrypted.Result.PlainText;
Console.WriteLine($"Original text: {plainText}. Decrypted text: {decryptedText}.");

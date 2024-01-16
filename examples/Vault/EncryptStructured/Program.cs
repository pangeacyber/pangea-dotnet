using System.Globalization;
using System.Text.Json;
using PangeaCyber.Net;
using PangeaCyber.Net.Vault;
using PangeaCyber.Net.Vault.Models;
using PangeaCyber.Net.Vault.Requests;

var cfg = Config.FromEnvironment("vault");
var client = new VaultClient.Builder(cfg).Build();

// First create an encryption key, either from the Pangea Console or programmatically as below.
var time = DateTimeOffset.UtcNow.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
var generateResponse = await client.SymmetricGenerate(
    new SymmetricGenerateRequest.Builder(
        SymmetricAlgorithm.AES256_CFB,
        KeyPurpose.Encryption,
        $".NET structured encrypt example {time}"
    ).Build()
);
var encryptionKeyId = generateResponse.Result.ID;

// Structured data that we'll encrypt.
var data = new Dictionary<string, string>
{
    { "foo", "bar" },
    { "some", "thing" }
};

// Encrypt
var encryptResponse = await client.EncryptStructured(
    new EncryptStructuredRequest<IDictionary<string, string>>(encryptionKeyId, data, "$.foo")
);
Console.WriteLine($"Encrypted result: {JsonSerializer.Serialize(encryptResponse.Result.StructuredData)}");

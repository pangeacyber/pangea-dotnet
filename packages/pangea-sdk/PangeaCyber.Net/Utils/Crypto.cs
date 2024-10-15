using System.Globalization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using PangeaCyber.Net.Vault.Results;
using PemWriter = Org.BouncyCastle.OpenSsl.PemWriter;

namespace PangeaCyber.Net
{
    /// <summary>Cryptography utilities.</summary>
    public static class Crypto
    {

        /// <summary>
        /// Initial value size on AES GCM
        /// </summary>
        private const int AES_GCM_IV_SIZE = 12;

        /// <summary>
        /// AES GCM tag size
        /// </summary>
        private const int AES_GCM_TAG_SIZE = 16;


        /// <summary>
        /// Generates a new RSA key pair of the given key size.
        /// </summary>
        /// <param name="dwKeySize">Key size.</param>
        /// <returns>RSA key pair.</returns>
        public static AsymmetricCipherKeyPair GenerateRsaKeyPair(int dwKeySize = 4096)
        {
            using var rsaProvider = new RSACryptoServiceProvider(dwKeySize);
            return DotNetUtilities.GetRsaKeyPair(rsaProvider);
        }

        /// <summary>
        /// Decrypt cipher text using the given asymmetric private key.
        /// </summary>
        /// <param name="cipher">Cipher to use.</param>
        /// <param name="privateKey">Asymmetric private key.</param>
        /// <param name="cipherText">Cipher text.</param>
        /// <returns>Decrypted bytes.</returns>
        /// <exception cref="ArgumentException">Thrown if a public key is passed.</exception>
        public static byte[] AsymmetricDecrypt(IAsymmetricBlockCipher cipher, AsymmetricKeyParameter privateKey, byte[] cipherText)
        {
            if (!privateKey.IsPrivate)
            {
                throw new ArgumentException("Expected a private key.", nameof(privateKey));
            }

            cipher.Init(false, privateKey);
            return cipher.ProcessBlock(cipherText, 0, cipherText.Length);
        }

        /// <summary>
        /// Export the given asymmetric public key in PEM format.
        /// </summary>
        /// <param name="publicKey">Asymmetric public key.</param>
        /// <returns>Asymmetric public key in PEM format.</returns>
        /// <exception cref="ArgumentException">Thrown if a private key is passed.</exception>
        public static string AsymmetricPemExport(AsymmetricKeyParameter publicKey)
        {
            if (publicKey.IsPrivate)
            {
                throw new ArgumentException("Expected a public key.", nameof(publicKey));
            }

            var buffer = new StringWriter(CultureInfo.InvariantCulture)
            {
                // Pangea Vault errors on CRLF.
                NewLine = "\n"
            };
            var pem = new PemWriter(buffer);
            pem.WriteObject(publicKey);
            pem.Writer.Flush();
            return buffer.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="result"></param>
        /// <param name="password"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string KEMDecrypt(ExportResult result, string password, AsymmetricKeyParameter privateKey)
        {
            // Decide which field to decrypt, only one should be present.
            var cipherEncoded = result.PrivateKey;
            if (cipherEncoded == null)
            {
                cipherEncoded = result.Key;
            }
            if (cipherEncoded == null)
            {
                throw new Exception("At least one of 'PrivateKey' or 'Key' should not be null.");
            }

            var cipherDecoded = Convert.FromBase64String(cipherEncoded);
            var cipher = cipherDecoded.Skip(AES_GCM_IV_SIZE).Take(cipherDecoded.Length - AES_GCM_IV_SIZE).ToArray();
            var iv = cipherDecoded.Take(AES_GCM_IV_SIZE).ToArray();
            var decodedEncryptedSalt = Convert.FromBase64String(result.EncryptedSalt);

            var decrypted = KEMDecrypt(
                cipher,
                decodedEncryptedSalt,
                iv,
                privateKey,
                result.AsymmetricAlgorithm!,
                result.SymmetricAlgorithm!,
                password,
                result.HashAlgorithm!,
                result.IterationCount,
                result.KDF
            );

            return System.Text.Encoding.UTF8.GetString(decrypted);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encryptedSalt"></param>
        /// <param name="iv"></param>
        /// <param name="privateKey"></param>
        /// <param name="asymmetricAlgorithm"></param>
        /// <param name="symmetricAlgorithm"></param>
        /// <param name="password"></param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="iterationCount"></param>
        /// <param name="kdf"></param>
        /// <returns></returns>
        private static byte[] KEMDecrypt(
            byte[] cipherText,
            byte[] encryptedSalt,
            byte[] iv,
            AsymmetricKeyParameter privateKey,
            string asymmetricAlgorithm,
            string symmetricAlgorithm,
            string password,
            string hashAlgorithm,
            int iterationCount,
            string kdf
        )
        {

            // FIXME: compare against enum value
            if (symmetricAlgorithm != "AES-GCM-256")
            {
                throw new Exception(string.Format("invalid symmetricAlgorithm: {0}", symmetricAlgorithm));
            }

            // FIXME: compare against enum value
            if (asymmetricAlgorithm != "RSA-NO-PADDING-4096-KEM")
            {
                throw new Exception(string.Format("invalid asymmetricAlgorithm: {0}", symmetricAlgorithm));
            }

            if (kdf != "pbkdf2")
            {
                throw new Exception(string.Format("invalid kdf: {0}", kdf));
            }

            if (hashAlgorithm != "sha512")
            {
                throw new Exception(string.Format("invalid hashAlgorithm: {0}", hashAlgorithm));
            }
            var hashAlgorithmName = KeyDerivationPrf.HMACSHA512;

            // Decrypt no padding
            var salt = AsymmetricDecrypt(new RsaEngine(), privateKey, encryptedSalt);
            var keyLength = GetKeyLength(symmetricAlgorithm);
            var symmetricKey = KeyDerivation.Pbkdf2(password, salt, hashAlgorithmName, iterationCount, keyLength);

            return AESGCMDecrypt(symmetricKey, cipherText, iv, null);
        }

        /// <summary>
        /// AES GCM Decryption
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cipherText"></param>
        /// <param name="nonce"></param>
        /// <param name="associatedData"></param>
        /// <returns></returns>
        private static byte[] AESGCMDecrypt(byte[] key, byte[] cipherText, byte[] nonce, byte[]? associatedData)
        {
            var plaintextBytes = new byte[cipherText.Length - AES_GCM_TAG_SIZE];

            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), AES_GCM_TAG_SIZE * 8, nonce, associatedData);
            cipher.Init(false, parameters);

            var offset = cipher.ProcessBytes(cipherText, 0, cipherText.Length, plaintextBytes, 0);
            cipher.DoFinal(plaintextBytes, offset);

            return plaintextBytes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private static int GetKeyLength(string algorithm)
        {
            if (algorithm == "AES-GCM-256")
            {
                return 32;
            }

            throw new Exception(string.Format("unknown algorithm: %s", algorithm));
        }

    }
}

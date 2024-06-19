using System.Globalization;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using PemWriter = Org.BouncyCastle.OpenSsl.PemWriter;

namespace PangeaCyber.Net
{
    /// <summary>Cryptography utilities.</summary>
    public static class Crypto
    {
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
    }
}

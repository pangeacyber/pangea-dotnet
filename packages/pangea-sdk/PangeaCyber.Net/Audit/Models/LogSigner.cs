using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using PangeaCyber.Net.Exceptions;
using Org.BouncyCastle.Utilities.IO.Pem;


namespace PangeaCyber.Net.Audit
{
    /// <kind>enum</kind>
    /// <summary>
    /// LogSigner
    /// </summary>
    public sealed class LogSigner
    {
        ///
        string PrivateKeyFilename = default!;

        ///
        Ed25519PrivateKeyParameters PrivateKey = default!;

        ///
        Ed25519PublicKeyParameters PublicKey = default!;

        ///
        public LogSigner(string privateKeyFilename)
        {
            this.PrivateKeyFilename = privateKeyFilename;
        }

        ///
        public string Sign(string data)
        {
            if (this.PrivateKey == null || this.PublicKey == null)
            {
                this.loadKeys();
            }

            // create the signature
            var signer = new Ed25519Signer();
            byte[] message;
            try
            {
                message = Encoding.UTF8.GetBytes(data);
            }
            catch (EncoderFallbackException e)
            {
                throw new SignerException("Failed to convert message to sign. Encoding not supported", e);
            }

            signer.Reset();
            signer.Init(true, this.PrivateKey);
            signer.BlockUpdate(message, 0, message.Length);
            byte[] signature;
            try
            {
                signature = signer.GenerateSignature();
            }
            catch (Exception e)
            {
                throw new SignerException("Failed to generate signature", e);
            }

            return Convert.ToBase64String(signature);
        }

        private void loadKeys()
        {
            string key;
            try
            {
                key = File.ReadAllText(Path.GetFullPath(this.PrivateKeyFilename));
            }
            catch (IOException e)
            {
                throw new SignerException("Failed to load keys from file: " + this.PrivateKeyFilename, e);
            }

            string privateKeyPEM = key.Replace("-----BEGIN PRIVATE KEY-----", "").Replace(Environment.NewLine, "").Replace("-----END PRIVATE KEY-----", "");
            this.PrivateKey = new Ed25519PrivateKeyParameters(Convert.FromBase64String(privateKeyPEM), 16);
            this.PublicKey = this.PrivateKey.GeneratePublicKey();
        }

        ///
        // public string GetPublicKey()
        // {
        //     if (this.PrivateKey == null || this.PublicKey == null)
        //     {
        //         this.loadKeys();
        //     }
        //     return Convert.ToBase64String(this?.PublicKey?.GetEncoded() ?? default!);
        // }

        public string GetPublicKey()
        {
            try
            {
                var pemObject = new PemObject("PUBLIC KEY", this.PublicKey.GetEncoded());
                var stringWriter = new StringWriter();
                var pemWriter = new PemWriter(stringWriter);
                pemWriter.WriteObject(pemObject);
                pemWriter.Writer.Flush();
                string publicKeyPem = stringWriter.ToString();
                return publicKeyPem;
            }
            catch (Exception e)
            {
                throw new SignerException("Failed to get encoded public key", e);
            }
        }

        ///
        public string GetAlgorithm()
        {
            return "ED25519";
        }


    }
}

using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// Verifier
    /// </summary>
    public sealed class Verifier
    {
        ///        
        public EventVerification Verify(string pubKeyInput, string signatureBase64, string message)
        {
            const int KeyLength = 32;
            byte[] pubKeyBytes = new byte[KeyLength];

            if (pubKeyInput.StartsWith("-----")) {
                if (pubKeyInput.StartsWith("-----BEGIN PUBLIC KEY-----")) {
                    // Ed25519 header format
                    string publicKeyPEM = pubKeyInput
                        .Replace("-----BEGIN PUBLIC KEY-----", "")
                        .Replace(System.Environment.NewLine, "")
                        .Replace("-----END PUBLIC KEY-----", "");
                    var encoded = Convert.FromBase64String(publicKeyPEM);
                    Array.Copy(encoded, Math.Max(encoded.Length - KeyLength, 0), pubKeyBytes, 0, KeyLength);
                } else {
                    // Not supported formats
                    return EventVerification.NotVerified;
                }
            } else {
                pubKeyBytes = Convert.FromBase64String(pubKeyInput);
            }

            // verify the signature
            var verifier = new Ed25519Signer();
            Ed25519PublicKeyParameters pubKey = default!;
            try
            {
                pubKey = new Ed25519PublicKeyParameters(pubKeyBytes);
            }
            catch (Exception)
            {
                return EventVerification.Failed;
            }

            verifier.Init(false, pubKey);
            byte[] byteMessage;
            try
            {
                byteMessage = Encoding.UTF8.GetBytes(message);
            }
            catch (Exception)
            {
                return EventVerification.Failed;
            }

            verifier.BlockUpdate(byteMessage, 0, byteMessage.Length);
            bool verified = verifier.VerifySignature(Convert.FromBase64String(signatureBase64));
            return verified ? EventVerification.Success : EventVerification.Failed;
        }
    }
}
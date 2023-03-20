using System;
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
        public EventVerification Verify(string pubKeyBase64, string signatureBase64, string message)
        {
            // verify the signature
            var verifier = new Ed25519Signer();
            Ed25519PublicKeyParameters pubKey = default!;
            try
            {
                pubKey = new Ed25519PublicKeyParameters(Convert.FromBase64String(pubKeyBase64));
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
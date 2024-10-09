using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class KeyRotateRequest : CommonRotateRequest
    {
        /// <summary>
        /// The public key (in PEM format)
        /// </summary>
        [JsonProperty("public_key")]
        public string? EncodedPublicKey { get; set; }

        /// <summary>
        /// The private key (in PEM format)
        /// </summary>
        [JsonProperty("private_key")]
        public string? EncodedPrivateKey { get; set; }

        /// <summary>
        /// The key material
        /// </summary>
        [JsonProperty("key")]
        public string? EncodedSymmetricKey { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Item ID to be rotated</param>
        /// <param name="rotationState">State to which the previous version should transition upon rotation</param>
        public KeyRotateRequest(string id, ItemVersionState rotationState) : base(id)
        {
            RotationState = rotationState;
        }
    }
}

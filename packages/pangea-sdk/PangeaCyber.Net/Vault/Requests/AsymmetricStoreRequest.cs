using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class AsymmetricStoreRequest : CommonStoreRequest
    {
        /// <summary>
        /// The type of the item
        /// </summary>
        [JsonProperty("type")]
        public ItemType Type { get; set; }

        /// <summary>
        /// The algorithm of the key
        /// </summary>
        [JsonProperty("algorithm")]
        public AsymmetricAlgorithm Algorithm { get; set; }

        /// <summary>
        /// The purpose of the key
        /// </summary>
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; set; }

        /// <summary>
        /// The public key (in PEM format)
        /// </summary>
        [JsonProperty("public_key")]
        public string EncodedPublicKey { get; set; }

        /// <summary>
        /// The private key (in PEM format)
        /// </summary>
        [JsonProperty("private_key")]
        public string EncodedPrivateKey { get; set; }

        /// <summary>Whether the key is exportable or not.</summary>
        [JsonProperty("exportable")]
        public bool Exportable { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="encodedPrivateKey">Private key to store</param>
        /// <param name="encodedPublicKey">Public key to store</param>
        /// <param name="algorithm">Algorithm of the key pair to store</param>
        /// <param name="purpose">Purpose of the key pair to store</param>
        /// <param name="name">Name of the key pair</param>
        public AsymmetricStoreRequest(
                string encodedPrivateKey,
                string encodedPublicKey,
                AsymmetricAlgorithm algorithm,
                KeyPurpose purpose,
                string name)
                : base(name)
        {
            Algorithm = algorithm;
            Purpose = purpose;
            EncodedPublicKey = encodedPublicKey;
            EncodedPrivateKey = encodedPrivateKey;
        }
    }
}

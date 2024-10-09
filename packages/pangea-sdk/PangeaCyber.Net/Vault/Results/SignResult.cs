using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class SignResult
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// The signature of the message
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; } = default!;

        /// <summary>
        /// The algorithm of the key
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        /// <summary>
        /// The public key (in PEM format)
        /// </summary>
        [JsonProperty("public_key")]
        public string EncodedPublicKey { get; set; } = default!;

    }
}

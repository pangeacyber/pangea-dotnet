using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    /// <summary>Result of a key export.</summary>
    public sealed class ExportResult
    {
        /// <summary>The ID of the key to use.</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>The item version. Defaults to the current version.</summary>
        [JsonProperty("version")]
        public string Version { get; set; } = default!;

        /// <summary>The type of the key.</summary>
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>The state of the item.</summary>
        [JsonProperty("item_state")]
        public string ItemState { get; set; } = default!;

        /// <summary>The algorithm of the key.</summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        /// <summary>The public key (in PEM format).</summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = default!;

        /// <summary>The private key (in PEM format).</summary>
        [JsonProperty("private_key")]
        public string PrivateKey { get; set; } = default!;

        /// <summary>The key material.</summary>
        [JsonProperty("key")]
        public string Key { get; set; } = default!;

        /// <summary>
        /// Whether exported key(s) are encrypted with encryption_key sent on the
        /// request or not. If encrypted, the result is sent in base64, any other
        /// case they are in PEM format plain text.
        /// </summary>
        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; } = default!;

        /// <summary>Constructor.</summary>
        public ExportResult()
        {
        }
    }
}

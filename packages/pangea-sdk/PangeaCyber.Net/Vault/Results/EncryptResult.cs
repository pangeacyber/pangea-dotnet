using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class EncryptResult
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// The encrypted message (Base64 encoded)
        /// </summary>
        [JsonProperty("cipher_text")]
        public string CipherText { get; set; } = default!;

        /// <summary>
        /// The algorithm of the key
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

    }
}

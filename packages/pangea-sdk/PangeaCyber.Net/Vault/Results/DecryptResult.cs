using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class DecryptResult
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        /// The decrypted message
        /// </summary>
        [JsonProperty("plain_text")]
        public string PlainText { get; set; } = default!;

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; } = default!;

        /// <summary>
        /// The algorithm of the key
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        public DecryptResult()
        {
        }
    }
}

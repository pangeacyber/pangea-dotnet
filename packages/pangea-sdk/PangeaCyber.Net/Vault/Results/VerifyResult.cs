using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class VerifyResult
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
        /// The algorithm of the key
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        /// <summary>
        /// Indicates if messages have been verified.
        /// </summary>
        [JsonProperty("valid_signature")]
        public bool ValidSignature { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public VerifyResult()
        {
        }

    }
}

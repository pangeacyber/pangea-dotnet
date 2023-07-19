using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class VerifyResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int Version { get; set; }

        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        [JsonProperty("valid_signature")]
        public bool ValidSignature { get; set; }

        ///
        public VerifyResult()
        {
        }

    }
}

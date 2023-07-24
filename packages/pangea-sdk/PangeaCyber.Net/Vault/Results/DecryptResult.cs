using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class DecryptResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("plain_text")]
        public string PlainText { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int Version { get; set; } = default!;

        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        public DecryptResult()
        {
        }
    }
}

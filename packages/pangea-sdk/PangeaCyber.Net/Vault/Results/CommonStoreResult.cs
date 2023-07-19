using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class CommonStoreResult
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int? Version { get; set; } = default!;

        ///
        public CommonStoreResult()
        {
        }
    }
}

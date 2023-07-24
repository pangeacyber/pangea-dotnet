using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class CommonRotateResult
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int? Version { get; set; }

        ///
        public CommonRotateResult()
        {
        }
    }
}

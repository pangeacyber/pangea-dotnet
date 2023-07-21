using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class CommonGenerateResult
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonProperty("id")]
        public string? ID { get; set; }

        ///
        [JsonProperty("version")]
        public int? Version { get; set; }

        ///
        public CommonGenerateResult() { }
    }
}

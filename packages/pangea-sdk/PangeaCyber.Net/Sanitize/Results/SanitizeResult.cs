using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class SanitizeResult
    {
        ///
        [JsonProperty("dest_url")]
        public string? DestURL { get; set; }

        ///
        [JsonProperty("dest_share_id")]
        public string? DestShareID { get; set; }

        ///
        [JsonProperty("data")]
        public SanitizeData? Data { get; set; }

        ///
        [JsonProperty("parameters")]
        public Dictionary<string, object>? Parameters { get; set; }

        ///
        public SanitizeResult() { }
    }
}

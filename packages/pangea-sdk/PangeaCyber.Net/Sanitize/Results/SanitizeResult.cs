using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Sanitize result.</summary>
    public class SanitizeResult
    {
        /// <summary>A URL where the Sanitized file can be downloaded.</summary>
        [JsonProperty("dest_url")]
        public string? DestURL { get; set; }

        /// <summary>Pangea Secure Share ID of the Sanitized file.</summary>
        [JsonProperty("dest_share_id")]
        public string? DestShareID { get; set; }

        /// <summary>Data.</summary>
        [JsonProperty("data")]
        public SanitizeData? Data { get; set; }

        /// <summary>The parameters, which were passed in the request, echoed back</summary>
        [JsonProperty("parameters")]
        public Dictionary<string, object>? Parameters { get; set; }

        /// <summary>Constructor.</summary>
        public SanitizeResult() { }
    }
}

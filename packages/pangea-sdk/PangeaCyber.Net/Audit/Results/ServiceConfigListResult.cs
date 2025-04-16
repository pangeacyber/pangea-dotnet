using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit.Results
{
    /// <summary>
    /// Result of a service config list operation.
    /// </summary>
    public class ServiceConfigListResult
    {
        /// <summary>
        /// The total number of service configs matched by the list request.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Used to fetch the next page of the current listing when provided in a repeated request's last parameter.
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; } = null;

        /// <summary>
        /// List of service configs.
        /// </summary>
        [JsonProperty("items")]
        public List<ServiceConfig>? Items { get; set; } = null;
    }
}

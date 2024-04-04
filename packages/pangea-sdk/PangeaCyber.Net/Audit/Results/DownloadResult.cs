using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <summary>Downloaded search results.</summary>
    public sealed class DownloadResult
    {
        /// <summary>URL where search results can be downloaded.</summary>
        [JsonProperty("dest_url")]
        public string DestURL { get; private set; } = default!;

        /// <summary>
        /// The time when the results will no longer be available to page through via the results API.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; private set; } = default!;
    }
}

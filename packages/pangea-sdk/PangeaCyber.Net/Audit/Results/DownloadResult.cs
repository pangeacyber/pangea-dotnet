using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <summary>Downloaded search results.</summary>
    public sealed class DownloadResult
    {
        /// <summary>URL where search results can be downloaded.</summary>
        [JsonProperty("dest_url")]
        public string DestURL { get; private set; } = default!;
    }
}

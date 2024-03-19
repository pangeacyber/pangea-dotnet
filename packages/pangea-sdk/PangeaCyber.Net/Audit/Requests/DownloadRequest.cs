using Newtonsoft.Json;
using PangeaCyber.Net.Audit.Models;

namespace PangeaCyber.Net.Audit
{
    /// <summary>DownloadRequest</summary>
    public sealed class DownloadRequest : BaseRequest
    {
        /// <summary>ID returned by the search API.</summary>
        [JsonProperty("result_id", Required = Required.Always)]
        public string ResultID { get; set; } = default!;

        /// <summary>Format for the records.</summary>
        [JsonProperty("format")]
        public DownloadFormat? Format { get; set; }
    }
}

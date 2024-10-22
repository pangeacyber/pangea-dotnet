using Newtonsoft.Json;
using PangeaCyber.Net.Audit.Models;

namespace PangeaCyber.Net.Audit
{
    /// <summary>DownloadRequest</summary>
    public sealed class DownloadRequest : BaseRequest
    {
        /// <summary>ID returned by the search API.</summary>
        [JsonProperty("request_id")]
        public string? RequestID { get; set; }

        /// <summary>ID returned by the search API.</summary>
        [JsonProperty("result_id")]
        public string? ResultID { get; set; }

        /// <summary>Format for the records.</summary>
        [JsonProperty("format")]
        public DownloadFormat? Format { get; set; }

        /// <summary>Return the context data needed to decrypt secure audit events that have been redacted with format preserving encryption.</summary>
        [JsonProperty("return_context")]
        public bool? ReturnContext { get; set; }
    }
}

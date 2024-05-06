using Newtonsoft.Json;
using PangeaCyber.Net.Audit.Models;

namespace PangeaCyber.Net.Audit
{
    /// <summary>Export request parameters</summary>
    public sealed class ExportRequest : BaseRequest
    {
        /// <summary>Format for the records.</summary>
        [JsonProperty("format")]
        public DownloadFormat Format { get; set; } = DownloadFormat.CSV;

        /// <summary>The start of the time range to perform the search on.</summary>
        [JsonProperty("start")]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// The end of the time range to perform the search on. If omitted, then all records up to the latest will be
        /// searched.
        /// </summary>
        [JsonProperty("end")]
        public DateTimeOffset? End { get; set; }

        /// <summary>Specify the sort order of the response.</summary>
        [JsonProperty("order")]
        public string? Order { get; set; }

        /// <summary>Name of column to sort the results by.</summary>
        [JsonProperty("order_by")]
        public string? OrderBy { get; set; }

        /// <summary>
        /// Whether or not to include the root hash of the tree and the membership proof for each record.
        /// </summary>
        [JsonProperty("verbose")]
        public bool Verbose { get; set; } = true;
    }
}

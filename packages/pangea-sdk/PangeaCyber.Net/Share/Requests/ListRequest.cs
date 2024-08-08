using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ListRequest : BaseRequest
    {
        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

        /// <summary>If true, include the `external_bucket_key` in results.</summary>
        [JsonProperty("include_external_bucket_key")]
        public bool IncludeExternalBucketKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("filter")]
        public FilterList? Filter { get; set; }

        /// <summary>
        /// Reflected value from a previous response to obtain the next page of results.
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }

        /// <summary>
        /// Order results asc(ending) or desc(ending).
        /// </summary>
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        /// <summary>
        /// Which field to order results by.
        /// </summary>
        [JsonProperty("order_by")]
        public ItemOrderBy? OrderBy { get; set; }

        /// <summary>
        /// Maximum results to include in the response.
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }
    }
}

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
        ///
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("order_by")]
        public ItemOrderBy? OrderBy { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkListRequest : BaseRequest
    {
        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

        ///
        [JsonProperty("filter")]
        public FilterShareLinkList Filter { get; set; } = new FilterShareLinkList();

        /// <summary>
        /// Reflected value from a previous response to obtain the next page of results.
        /// </summary>
        [JsonProperty("last")]
        public string Last { get; set; } = default!;

        /// <summary>
        /// Order results asc(ending) or desc(ending).
        /// </summary>
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        /// <summary>
        /// Which field to order results by.
        /// </summary>
        [JsonProperty("order_by")]
        public ShareLinkOrderBy? OrderBy { get; set; }

        /// <summary>
        /// Maximum results to include in the response.
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }
    }
}

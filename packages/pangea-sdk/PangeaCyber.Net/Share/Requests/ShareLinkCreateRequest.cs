using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkCreateRequest : BaseRequest
    {

        /// <summary>
        /// The bucket to use, if not the default.
        /// </summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

        ///
        [JsonProperty("links")]
        public List<ShareLinkCreateItem> Links { get; set; } = new List<ShareLinkCreateItem>();
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkDeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("ids")]
        public List<string> IDs { get; set; } = new List<string>();

        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }
    }
}

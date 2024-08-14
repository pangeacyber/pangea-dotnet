using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkGetRequest : BaseRequest
    {
        /// <summary>
        /// The ID of a share link.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;
    }
}

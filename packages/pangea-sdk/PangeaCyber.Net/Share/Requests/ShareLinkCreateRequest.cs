using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("links")]
        public List<ShareLinkCreateItem> Links { get; set; } = new List<ShareLinkCreateItem>();
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Requests
{
    ///
    public class ShareLinkCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("links")]
        public List<ShareLinkCreateItem> Links { get; set; } = new List<ShareLinkCreateItem>();
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Results
{
    ///
    public class ShareLinkListResult
    {
        ///
        [JsonProperty("count")]
        public int Count { get; set; }

        ///
        [JsonProperty("share_link_objects")]
        public List<ShareLinkItem> ShareLinkObjects { get; set; } = new List<ShareLinkItem>();
    }
}

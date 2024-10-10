using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    ///
    public class ShareLinkDeleteResult
    {
        ///
        [JsonProperty("share_link_objects")]
        public List<ShareLinkItem> ShareLinkObjects { get; set; } = new List<ShareLinkItem>();
    }
}

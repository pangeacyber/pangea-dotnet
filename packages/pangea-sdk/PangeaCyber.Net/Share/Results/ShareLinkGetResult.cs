using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    ///
    public class ShareLinkGetResult
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("share_link_object")]
        public ShareLinkItem ShareLinkObject { get; set; } = new ShareLinkItem();
    }
}

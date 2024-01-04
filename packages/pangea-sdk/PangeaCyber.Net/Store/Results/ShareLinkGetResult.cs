using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Results
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

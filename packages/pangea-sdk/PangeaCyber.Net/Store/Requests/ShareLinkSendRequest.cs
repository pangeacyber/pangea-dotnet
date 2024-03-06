using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Requests
{
    ///
    public class ShareLinkSendRequest : BaseRequest
    {
        ///
        [JsonProperty("links")]
        public List<ShareLinkSendItem> Links { get; set; }

        ///
        [JsonProperty("sender_email")]
        public string SenderEmail { get; set; }

        ///
        [JsonProperty("sender_name")]
        public string? SenderName { get; set; } = null;

        ///
        public ShareLinkSendRequest(List<ShareLinkSendItem> links, string senderEmail)
        {
            this.Links = links;
            this.SenderEmail = senderEmail;
        }

    }
}

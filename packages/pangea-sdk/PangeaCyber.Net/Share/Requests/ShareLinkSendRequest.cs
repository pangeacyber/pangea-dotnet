using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
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

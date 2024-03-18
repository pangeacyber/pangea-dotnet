using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkSendRequest : BaseRequest
    {
        ///
        [JsonProperty("links")]
        public IList<ShareLinkSendItem> Links { get; set; }

        ///
        [JsonProperty("sender_email")]
        public string SenderEmail { get; set; }

        ///
        [JsonProperty("sender_name")]
        public string? SenderName { get; set; }

        ///
        public ShareLinkSendRequest(IList<ShareLinkSendItem> links, string senderEmail)
        {
            this.Links = links;
            this.SenderEmail = senderEmail;
        }
    }
}

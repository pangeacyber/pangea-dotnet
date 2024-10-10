using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents an item for sending a share link.
    /// </summary>
    public class ShareLinkSendItem
    {
        /// <summary>
        /// Gets or sets the id of the link.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Create a new ShareLinkSendItem with id and email.
        /// </summary>
        public ShareLinkSendItem(string id, string email)
        {
            this.ID = id;
            this.Email = email;
        }
    }
}

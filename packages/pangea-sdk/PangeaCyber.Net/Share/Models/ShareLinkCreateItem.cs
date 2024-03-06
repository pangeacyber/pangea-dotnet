using System.Collections.Generic;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents an item for creating a share link.
    /// </summary>
    public class ShareLinkCreateItem
    {
        /// <summary>
        /// Gets or sets the list of targets.
        /// </summary>
        [JsonProperty("targets")]
        public List<string> Targets { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        [JsonProperty("link_type")]
        public LinkType? LinkType { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the link.
        /// </summary>
        [JsonProperty("expires_at")]
        public string? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the maximum access count.
        /// </summary>
        [JsonProperty("max_access_count")]
        public int? MaxAccessCount { get; set; }

        /// <summary>
        /// Gets or sets the list of authenticators.
        /// </summary>
        [JsonProperty("authenticators")]
        public List<Authenticator> Authenticators { get; set; } = new List<Authenticator>();

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the notify email.
        /// </summary>
        [JsonProperty("notify_email")]
        public string? NotifyEmail { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; } = null;
    }


}

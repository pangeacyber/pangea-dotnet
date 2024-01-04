using System.Collections.Generic;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Store.Models
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
    }
}

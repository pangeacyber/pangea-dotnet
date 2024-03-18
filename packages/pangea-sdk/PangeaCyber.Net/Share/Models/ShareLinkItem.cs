using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents a share link item.
    /// </summary>
    public class ShareLinkItem
    {
        /// <summary>
        /// Gets or sets the ID of the share link.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        /// Gets or sets the ID of the storage pool.
        /// </summary>
        [JsonProperty("storage_pool_id")]
        public string StoragePoolID { get; set; } = default!;

        /// <summary>
        /// Gets or sets the list of targets.
        /// </summary>
        [JsonProperty("targets")]
        public List<string> Targets { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        [JsonProperty("link_type")]
        public string LinkType { get; set; } = default!;

        /// <summary>
        /// Gets or sets the access count.
        /// </summary>
        [JsonProperty("access_count")]
        public int AccessCount { get; set; }

        /// <summary>
        /// Gets or sets the maximum access count.
        /// </summary>
        [JsonProperty("max_access_count")]
        public int MaxAccessCount { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the share link.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        /// <summary>
        /// Gets or sets the expiration date of the share link.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; } = default!;

        /// <summary>
        /// Gets or sets the last accessed date of the share link.
        /// </summary>
        [JsonProperty("last_accessed_at")]
        public string? LastAccessedAt { get; set; }

        /// <summary>
        /// Gets or sets the list of authenticators.
        /// </summary>
        [JsonProperty("authenticators")]
        public List<Authenticator> Authenticators { get; set; } = new List<Authenticator>();

        /// <summary>
        /// Gets or sets the share link.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; } = default!;

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
        public Tags? Tags { get; set; } = new Tags();
    }
}

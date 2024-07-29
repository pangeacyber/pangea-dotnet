using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents item data.
    /// </summary>
    public class ItemData
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        /// <summary>
        /// Gets or sets the last update timestamp.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; } = default!;

        /// <summary>
        /// Gets or sets the item size (optional).
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// Gets or sets the billable size (optional).
        /// </summary>
        [JsonProperty("billable_size")]
        public int? BillableSize { get; set; }

        /// <summary>
        /// Gets or sets the item location (optional).
        /// </summary>
        [JsonProperty("location")]
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the item tags (optional).
        /// </summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        /// <summary>
        /// Gets or sets the item metadata (optional).
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        /// <summary>
        /// Gets or sets the MD5 hash (optional).
        /// </summary>
        [JsonProperty("md5")]
        public string? MD5 { get; set; }

        /// <summary>
        /// Gets or sets the SHA256 hash (optional).
        /// </summary>
        [JsonProperty("sha256")]
        public string? SHA256 { get; set; }

        /// <summary>
        /// Gets or sets the SHA512 hash (optional).
        /// </summary>
        [JsonProperty("sha512")]
        public string? SHA512 { get; set; }

        /// <summary>
        /// Gets or sets the parent ID (optional).
        /// </summary>
        [JsonProperty("parent_id")]
        public string? ParentID { get; set; }

        /// <summary>The key in the external bucket that contains this file.</summary>
        [JsonProperty("external_bucket_key")]
        public string? ExternalBucketKey { get; set; }
    }
}
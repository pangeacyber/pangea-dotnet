using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class ItemData
    {
        /// <summary>The type of the item</summary>
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>The ID of the item</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>Latest version number</summary>
        [JsonProperty("num_versions")]
        public int? NumVersions { get; set; }

        /// <summary>True if the item is enabled</summary>
        [JsonProperty("enabled")]
        public string? Enabled { get; set; }

        /// <summary>The name of this item</summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>The folder where this item is stored</summary>
        [JsonProperty("folder")]
        public string? Folder { get; set; }

        /// <summary>User-provided metadata</summary>
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        /// <summary>A list of user-defined tags</summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        /// <summary>Period of time between item rotations.</summary>
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        /// <summary>State to which the previous version should transition upon rotation</summary>
        [JsonProperty("rotation_state")]
        public string? RotationState { get; set; }

        /// <summary>Timestamp of the last rotation (if any)</summary>
        [JsonProperty("last_rotated")]
        public string? LastRotated { get; set; }

        /// <summary>Timestamp of the next rotation, if auto rotation is enabled.</summary>
        [JsonProperty("next_rotation")]
        public string? NextRotation { get; set; }

        /// <summary>Timestamp indicating when the item will be disabled</summary>
        [JsonProperty("disabled_at")]
        public string? DisabledAt { get; set; }

        /// <summary>Timestamp indicating when the item was created</summary>
        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }

        /// <summary>The algorithm of the key</summary>
        [JsonProperty("algorithm")]
        public string? Algorithm { get; set; }

        /// <summary>The purpose of the key</summary>
        [JsonProperty("purpose")]
        public string? Purpose { get; set; }

        /// <summary>Grace period for the previous version of the secret</summary>
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; set; }

        /// <summary>Whether the key is exportable or not</summary>
        [JsonProperty("exportable")]
        public bool? Exportable { get; set; }

        /// <summary></summary>
        [JsonProperty("client_id")]
        public string? ClientID { get; set; }

        /// <summary>For settings that inherit a value from a parent folder, the full path of the folder where the value is set</summary>
        [JsonProperty("inherited_settings")]
        public InheritedSettings? InheritedSettings { get; set; }

        ///
        [JsonProperty("item_versions")]
        public ItemVersionData[]? ItemVersions { get; set; }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class ItemData
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonProperty("id")]
        public string? ID { get; set; }

        ///
        [JsonProperty("current_version")]
        public ItemVersionData? CurrentVersion { get; set; }

        ///
        [JsonProperty("name")]
        public string? Name { get; set; }

        ///
        [JsonProperty("folder")]
        public string? Folder { get; set; }

        ///
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        ///
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        ///
        [JsonProperty("rotation_state")]
        public string? RotationState { get; set; }

        ///
        [JsonProperty("last_rotated")]
        public string? LastRotated { get; set; }

        ///
        [JsonProperty("next_rotation")]
        public string? NextRotation { get; set; }

        ///
        [JsonProperty("expiration")]
        public string? Expiration { get; set; }

        ///
        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }

        ///
        [JsonProperty("algorithm")]
        public string? Algorithm { get; set; }

        ///
        [JsonProperty("purpose")]
        public string? Purpose { get; set; }

        /// <summary>Whether the key is exportable or not</summary>
        [JsonProperty("exportable")]
        public bool? Exportable { get; set; }
    }
}

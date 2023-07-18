using System.Text.Json.Serialization;

namespace PangeaCyber.Net.Vault
{
    ///
    public class ItemData
    {
        ///
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonPropertyName("id")]
        public string? ID { get; set; }

        ///
        [JsonPropertyName("current_version")]
        public ItemVersionData? CurrentVersion { get; set; }

        ///
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        ///
        [JsonPropertyName("folder")]
        public string? Folder { get; set; }

        ///
        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        ///
        [JsonPropertyName("tags")]
        public Tags? Tags { get; set; }

        ///
        [JsonPropertyName("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        ///
        [JsonPropertyName("rotation_state")]
        public string? RotationState { get; set; }

        ///
        [JsonPropertyName("last_rotated")]
        public string? LastRotated { get; set; }

        ///
        [JsonPropertyName("next_rotation")]
        public string? NextRotation { get; set; }

        ///
        [JsonPropertyName("expiration")]
        public string? Expiration { get; set; }

        ///
        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        ///
        [JsonPropertyName("algorithm")]
        public string? Algorithm { get; set; }

        ///
        [JsonPropertyName("purpose")]
        public string? Purpose { get; set; }
    }
}

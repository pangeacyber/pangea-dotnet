using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class ItemVersionData
    {
        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; } = default!;

        /// <summary>
        /// The state of the item version
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; } = default!;

        /// <summary>
        /// Timestamp indicating when the item was created
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        /// <summary>
        /// Timestamp indicating when the item version will be destroyed
        /// </summary>
        [JsonProperty("destroyed_at")]
        public string? DestroyedAt { get; set; }

        /// <summary>
        /// Timestamp indicating when the item version will be rotated
        /// </summary>
        [JsonProperty("rotated_at")]
        public string? RotatedAt { get; set; }

        ///
        [JsonProperty("secret")]
        public string? Secret { get; set; }

        ///
        [JsonProperty("token")]
        public string? Token { get; set; }

        ///
        [JsonProperty("client_secret")]
        public string? ClientSecret { get; set; }

        ///
        [JsonProperty("client_secret_id")]
        public string? ClientSecretID { get; set; }

        ///
        [JsonProperty("public_key")]
        public string? EncodedPublicKey { get; set; }
    }
}

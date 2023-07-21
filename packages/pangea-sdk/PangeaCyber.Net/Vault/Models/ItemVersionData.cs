using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    public class ItemVersionData
    {
        ///
        [JsonProperty("version")]
        public int Version { get; set; } = default!;

        ///
        [JsonProperty("state")]
        public string State { get; set; } = default!;

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        ///
        [JsonProperty("destroy_at")]
        public string? DestroyAt { get; set; }

        ///
        [JsonProperty("secret")]
        public string? Secret { get; set; }

        ///
        [JsonProperty("public_key")]
        public string? EncodedPublicKey { get; set; }
    }
}

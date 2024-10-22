using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>Authenticator.</summary>
    public sealed class Authenticator
    {
        /// <summary>An ID for an authenticator.</summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        /// <summary>An authentication mechanism.</summary>
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>Provider.</summary>
        [JsonProperty("provider")]
        public string? Provider { get; set; }

        /// <summary>Provider name.</summary>
        [JsonProperty("provider_name")]
        public string? ProviderName { get; set; }

        /// <summary>RPID.</summary>
        [JsonProperty("rpid")]
        public string? Rpid { get; set; }

        /// <summary>Enabled.</summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = default!;

        /// <summary>Phase.</summary>
        [JsonProperty("phase")]
        public string? Phase { get; set; }

        /// <summary>Enrolling browser.</summary>
        [JsonProperty("enrolling_browser")]
        public string? EnrollingBrowser { get; set; }

        /// <summary>Enrolling IP.</summary>
        [JsonProperty("enrolling_ip")]
        public string? EnrollingIp { get; set; }

        /// <summary>A time in ISO-8601 format.</summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        /// <summary>A time in ISO-8601 format.</summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; } = default!;

        /// <summary>State.</summary>
        [JsonProperty("state")]
        public string? State { get; set; }

        /// <summary>Default constructor for <see cref="Authenticator"/>.</summary>
        public Authenticator() { }
    }
}

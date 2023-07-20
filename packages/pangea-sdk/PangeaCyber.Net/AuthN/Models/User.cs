using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class User
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("email")]
        public string Email { get; set; } = default!;

        ///
        [JsonProperty("profile")]
        public Profile? Profile { get; set; }

        ///
        [JsonProperty("scopes")]
        public Scopes? Scopes { get; set; }

        ///
        [JsonProperty("id_providers")]
        public List<string>? IDProviders { get; set; }

        ///
        [JsonProperty("mfa_providers")]
        public List<string>? MFAProviders { get; set; }

        ///
        [JsonProperty("require_mfa")]
        public bool? RequireMFA { get; set; }

        ///
        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        ///
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        ///
        [JsonProperty("last_login_at")]
        public string? LastLoginAt { get; set; }

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;
    }
}

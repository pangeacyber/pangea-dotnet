using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    ///
    public class UserProfileGetResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; } = default!;

        ///
        [JsonProperty("email")]
        public string Email { get; private set; } = default!;

        ///
        [JsonProperty("profile")]
        public Profile? Profile { get; private set; }

        ///
        [JsonProperty("id_providers")]
        public IDProviders? IDProviders { get; private set; }

        ///
        [JsonProperty("mfa_providers")]
        public MFAProviders? MFAProviders { get; private set; }

        ///
        [JsonProperty("require_mfa")]
        public bool RequireMFA { get; private set; }

        ///
        [JsonProperty("verified")]
        public bool Verified { get; private set; }

        ///
        [JsonProperty("disabled")]
        public bool? Disabled { get; private set; }

        ///
        [JsonProperty("last_login_at")]
        public string? LastLoginAt { get; private set; }

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; } = default!;

        ///
        public UserProfileGetResult() { }

    }
}
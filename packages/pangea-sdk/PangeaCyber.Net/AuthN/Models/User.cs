using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class User
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("profile")]
        public Profile Profile { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("accepted_eula_id")]
        public string? AcceptedEulaId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("accepted_privacy_policy_id")]
        public string? AcceptedPrivacyPolicyId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("last_login_at")]
        public string? LastLoginAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("login_count")]
        public int LoginCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("last_login_ip")]
        public string? LastLoginIp { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("last_login_city")]
        public string? LastLoginCity { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("last_login_country")]
        public string? LastLoginCountry { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("authenticators")]
        public Authenticator[]? Authenticators { get; set; }
    }
}

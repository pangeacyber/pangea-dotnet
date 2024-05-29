using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class User
    {
        /// <summary>The identity of a user or a service.</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string Email { get; set; } = default!;

        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string Username { get; set; } = default!;

        /// <summary>A user profile as a collection of string properties.</summary>
        [JsonProperty("profile")]
        public Profile Profile { get; set; } = default!;

        /// <summary>True if the user's email has been verified.</summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; } = default!;

        /// <summary>True if the service administrator has disabled user account.</summary>
        [JsonProperty("disabled")]
        public bool Disabled { get; set; } = default!;

        /// <summary>An ID for an agreement.</summary>
        [JsonProperty("accepted_eula_id")]
        public string? AcceptedEulaId { get; set; }

        /// <summary>An ID for an agreement.</summary>
        [JsonProperty("accepted_privacy_policy_id")]
        public string? AcceptedPrivacyPolicyId { get; set; }

        /// <summary>A time in ISO-8601 format.</summary>
        [JsonProperty("last_login_at")]
        public string? LastLoginAt { get; set; }

        /// <summary>A time in ISO-8601 format.</summary>
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

        /// <summary>A list of authenticators.</summary>
        [JsonProperty("authenticators")]
        public Authenticator[]? Authenticators { get; set; }
    }
}

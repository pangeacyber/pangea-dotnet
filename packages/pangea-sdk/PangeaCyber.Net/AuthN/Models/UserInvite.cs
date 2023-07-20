using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserInvite
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("inviter")]
        public string Inviter { get; set; } = default!;

        ///
        [JsonProperty("invite_org")]
        public string InviteOrg { get; set; } = default!;

        ///
        [JsonProperty("email")]
        public string Email { get; set; } = default!;

        ///
        [JsonProperty("callback")]
        public string Callback { get; set; } = default!;

        ///
        [JsonProperty("state")]
        public string State { get; set; } = default!;

        ///
        [JsonProperty("require_mfa")]
        public bool? RequireMFA { get; set; }

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;

        ///
        [JsonProperty("expire")]
        public string? Expire { get; set; }
    }
}

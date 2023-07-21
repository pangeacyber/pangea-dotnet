using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserInviteListResult
    {
        ///
        [JsonProperty("invites")]
        public UserInvite[] Invites { get; private set; } = default!;

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        [JsonProperty("count")]
        public int? Count { get; private set; }

        ///
        public UserInviteListResult(){}
    }
}

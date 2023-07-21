using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AuthN
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserInviteListOrderBy
    {
        ///
        [JsonProperty("id")]
        ID,

        ///
        [JsonProperty("created_at")]
        CreatedAt,

        ///
        [JsonProperty("type")]
        Type,

        ///
        [JsonProperty("email")]
        Email,

        ///
        [JsonProperty("expire")]
        Expire,

        ///
        [JsonProperty("callback")]
        Callback,

        ///
        [JsonProperty("state")]
        State,

        ///
        [JsonProperty("inviter")]
        Inviter,

        ///
        [JsonProperty("invite_org")]
        InviteOrg
    }
}

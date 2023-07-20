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
        CREATED_AT,

        ///
        [JsonProperty("type")]
        TYPE,

        ///
        [JsonProperty("email")]
        EMAIL,

        ///
        [JsonProperty("expire")]
        EXPIRE,

        ///
        [JsonProperty("callback")]
        CALLBACK,

        ///
        [JsonProperty("state")]
        STATE,

        ///
        [JsonProperty("inviter")]
        INVITER,

        ///
        [JsonProperty("invite_org")]
        INVITE_ORG
    }
}

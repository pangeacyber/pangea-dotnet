using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AuthN
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserListOrderBy
    {
        ///
        [JsonProperty("id")]
        ID,

        ///
        [JsonProperty("created_at")]
        CREATED_AT,

        ///
        [JsonProperty("last_login_at")]
        LAST_LOGIN_AT,

        ///
        [JsonProperty("email")]
        EMAIL
    }
}

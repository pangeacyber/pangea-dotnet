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
        CreatedAt,

        ///
        [JsonProperty("last_login_at")]
        LastLoginAt,

        ///
        [JsonProperty("email")]
        Email
    }
}

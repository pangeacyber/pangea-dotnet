using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AuthN
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SessionOrderBy
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
        [JsonProperty("identity")]
        IDENTITY,

        ///
        [JsonProperty("email")]
        EMAIL,

        ///
        [JsonProperty("expire")]
        EXPIRE,

        ///
        [JsonProperty("active_token_id")]
        ACTIVE_TOKEN_ID
    }
}

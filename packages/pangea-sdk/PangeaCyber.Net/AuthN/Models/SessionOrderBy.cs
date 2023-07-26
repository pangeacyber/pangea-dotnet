using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AuthN.Models
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
        CreatetAt,

        ///
        [JsonProperty("type")]
        Type,

        ///
        [JsonProperty("identity")]
        Identity,

        ///
        [JsonProperty("email")]
        Email,

        ///
        [JsonProperty("expire")]
        Expire,

        ///
        [JsonProperty("active_token_id")]
        ActiveTokenID
    }
}

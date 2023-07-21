using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum IDProvider
    {
        ///
        [JsonProperty("facebook")]
        Facebook,

        ///
        [JsonProperty("github")]
        Github,

        ///
        [JsonProperty("google")]
        Google,

        ///
        [JsonProperty("microsoftonline")]
        Microsoft,

        ///
        [JsonProperty("password")]
        Password
    }
}

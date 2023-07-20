using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum FlowType
    {
        ///
        [JsonProperty("signin")]
        Signin,

        ///
        [JsonProperty("signup")]
        Signup
    }
}

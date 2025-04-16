using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Management;

[JsonConverter(typeof(StringEnumConverter))]
public enum AccessClientTokenAuth
{
    [JsonProperty("client_secret_basic")]
    ClientSecretBasic,

    [JsonProperty("client_secret_post")]
    ClientSecretPost
}

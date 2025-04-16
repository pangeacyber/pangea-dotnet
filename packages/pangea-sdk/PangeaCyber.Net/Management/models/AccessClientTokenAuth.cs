using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AccessClientTokenAuth
{
    ClientSecretBasic,
    ClientSecretPost
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Management;

[JsonConverter(typeof(StringEnumConverter))]
public enum AccessRegistryGroup
{
    [JsonProperty("ai-guard-edge")]
    AiGuardEdge,

    [JsonProperty("redact-edge")]
    RedactEdge,

    [JsonProperty("private-cloud")]
    PrivateCloud
}

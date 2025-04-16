using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessClientSecretInfoListResult
{
    [JsonProperty(Required = Required.Always)]
    public List<AccessClientSecretInfo> Secrets { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public int Count { get; set; }

    public string Last { get; set; } = default!;
}

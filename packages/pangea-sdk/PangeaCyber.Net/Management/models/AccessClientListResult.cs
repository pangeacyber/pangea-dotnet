using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessClientListResult
{
    [JsonProperty(Required = Required.Always)]
    public IList<AccessClientInfo> Clients { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public int Count { get; set; }

    public string Last { get; set; } = default!;
}

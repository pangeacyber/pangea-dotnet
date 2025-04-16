using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessClientSecretMetadata
{
    [JsonProperty(Required = Required.Always)]
    public string SourceIp { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string UserAgent { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string CreatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string UpdatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string LastUsedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string LastUsedIp { get; set; } = default!;
}

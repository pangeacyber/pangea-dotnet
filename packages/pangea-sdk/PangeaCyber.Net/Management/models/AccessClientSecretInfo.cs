using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessClientSecretInfo
{
    [JsonProperty(Required = Required.Always)]
    public string ClientId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecret { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretExpiresAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretId { get; set; } = default!;

    public string ClientSecretName { get; set; } = default!;

    public string ClientSecretDescription { get; set; } = default!;
}

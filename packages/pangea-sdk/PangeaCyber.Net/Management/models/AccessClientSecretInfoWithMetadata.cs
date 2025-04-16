using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessClientSecretInfoWithMetadata
{
    [JsonProperty(Required = Required.Always)]
    public string ClientId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecret { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretExpiresAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretName { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretDescription { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretCreatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretLastUsedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretLastUsedIp { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretLastUsedUserAgent { get; set; } = default!;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AccessClientCreateInfo : AccessClientInfo
{
    [JsonProperty(Required = Required.Always)]
    public string ClientSecret { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretExpiresAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretName { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretDescription { get; set; } = default!;
}

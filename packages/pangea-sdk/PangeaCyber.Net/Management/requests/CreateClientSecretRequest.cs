using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreateClientSecretRequest : BaseRequest
{
    [JsonProperty(Required = Required.Always)]
    public string ClientId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientSecretId { get; set; } = default!;

    public int? ClientSecretExpiresIn { get; set; }
    public string? ClientSecretName { get; set; }
    public string? ClientSecretDescription { get; set; }
}

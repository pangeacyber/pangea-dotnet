using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessClientInfo
{
    [JsonProperty(Required = Required.Always)]
    public string ClientId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string CreatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string UpdatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientName { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Scope { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public AccessClientTokenAuth TokenEndpointAuthMethod { get; set; }

    [JsonProperty(Required = Required.Always)]
    public List<string> RedirectUris { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public List<string> GrantTypes { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public List<string> ResponseTypes { get; set; } = default!;

    public int? ClientTokenExpiresIn { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string OwnerId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string OwnerUsername { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string CreatorId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string ClientClass { get; set; } = default!;
}

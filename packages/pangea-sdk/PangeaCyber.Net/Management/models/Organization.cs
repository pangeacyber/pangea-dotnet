using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Organization
{
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Description { get; set; } = default!;

    public string OwnerEmail { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string CreatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string UpdatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Status { get; set; } = default!;
}

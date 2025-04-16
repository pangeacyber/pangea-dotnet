using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Project
{
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Org { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string CreatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string UpdatedAt { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Geo { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string Region { get; set; } = default!;
}

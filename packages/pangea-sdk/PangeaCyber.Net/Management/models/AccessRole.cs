using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class AccessRole
{
    [JsonProperty(Required = Required.Always)]
    public string Role { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string RoleId { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string RoleName { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public string RoleDescription { get; set; } = default!;

    public string Service { get; set; } = default!;

    public string ServiceConfigId { get; set; } = default!;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreateProjectRequest : BaseRequest
{
    /// <summary>
    /// An Organization Pangea ID
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string OrgId { get; set; } = default!;

    /// <summary>
    /// The name of the project
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// The geographical region for the project
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Geo { get; set; } = default!;

    /// <summary>
    /// Optional region for the project
    /// </summary>
    public string? Region { get; set; }
}

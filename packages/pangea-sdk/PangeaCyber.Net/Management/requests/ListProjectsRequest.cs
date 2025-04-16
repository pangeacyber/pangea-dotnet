using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ListProjectsRequest : BaseRequest
{
    /// <summary>
    /// An Organization Pangea ID
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string OrgId { get; set; } = default!;

    /// <summary>
    /// Optional filter criteria
    /// </summary>
    public ListProjectsFilter? Filter { get; set; }

    /// <summary>
    /// Optional offset for pagination
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// Optional limit for pagination
    /// </summary>
    public int? Limit { get; set; }
}

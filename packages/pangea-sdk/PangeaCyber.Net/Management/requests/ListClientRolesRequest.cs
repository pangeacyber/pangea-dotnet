using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ListClientRolesRequest : BaseRequest
{
    /// <summary>
    /// Filter by resource type
    /// </summary>
    public string? ResourceType { get; set; }

    /// <summary>
    /// Filter by resource ID
    /// </summary>
    public string? ResourceId { get; set; }

    /// <summary>
    /// Filter by role
    /// </summary>
    public string? Role { get; set; }
}

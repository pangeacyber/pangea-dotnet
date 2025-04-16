using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class RevokeClientAccessRequest : BaseRequest
{
    /// <summary>
    /// A list of roles
    /// </summary>
    public IList<AccessRole>? Roles { get; set; }

    /// <summary>
    /// A list of space separated scope
    /// </summary>
    public string? Scope { get; set; }
}

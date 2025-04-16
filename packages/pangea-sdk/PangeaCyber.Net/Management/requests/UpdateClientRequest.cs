using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UpdateClientRequest : BaseRequest
{
    public string? ClientName { get; set; }
    public string? Scope { get; set; }
    public AccessClientTokenAuth? TokenEndpointAuthMethod { get; set; }
    public IList<string>? RedirectUris { get; set; }
    public IList<string>? GrantTypes { get; set; }
}

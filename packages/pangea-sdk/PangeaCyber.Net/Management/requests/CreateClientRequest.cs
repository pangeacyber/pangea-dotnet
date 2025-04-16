using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreateClientRequest : BaseRequest
{
    /// <summary>
    /// The name of the client
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string ClientName { get; set; } = default!;

    /// <summary>
    /// A list of space separated scope
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Scope { get; set; } = default!;

    /// <summary>
    /// The authentication method for the token endpoint
    /// </summary>
    public AccessClientTokenAuth? TokenEndpointAuthMethod { get; set; }

    /// <summary>
    /// A list of allowed redirect URIs for the client
    /// </summary>
    public IList<string>? RedirectUris { get; set; }

    /// <summary>
    /// A list of OAuth grant types that the client can use
    /// </summary>
    public IList<string>? GrantTypes { get; set; }

    /// <summary>
    /// A list of OAuth response types that the client can use
    /// </summary>
    public IList<string>? ResponseTypes { get; set; }

    /// <summary>
    /// A positive time duration in seconds or null
    /// </summary>
    public int? ClientSecretExpiresIn { get; set; }

    /// <summary>
    /// A positive time duration in seconds or null
    /// </summary>
    public int? ClientTokenExpiresIn { get; set; }

    /// <summary>
    /// The name of the client secret
    /// </summary>
    public string? ClientSecretName { get; set; }

    /// <summary>
    /// The description of the client secret
    /// </summary>
    public string? ClientSecretDescription { get; set; }

    /// <summary>
    /// A list of roles
    /// </summary>
    public IList<AccessRole>? Roles { get; set; }
}

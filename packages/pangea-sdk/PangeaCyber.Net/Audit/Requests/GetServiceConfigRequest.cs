using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Request to get a service configuration.
/// </summary>
public class GetServiceConfigRequest : BaseRequest
{
    /// <summary>
    /// The config ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = default!;
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Request to delete a service configuration.
/// </summary>
public class DeleteServiceConfigRequest : BaseRequest
{
    /// <summary>
    /// Config ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = default!;
}

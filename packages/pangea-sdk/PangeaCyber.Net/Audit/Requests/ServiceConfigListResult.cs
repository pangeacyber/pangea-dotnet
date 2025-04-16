using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Result of listing service configurations.
/// </summary>
public class ServiceConfigListResult : BaseRequest
{
    /// <summary>
    /// List of service configurations matching the filter criteria.
    /// </summary>
    [JsonProperty("configs")]
    public List<ServiceConfig> Configs { get; set; } = new List<ServiceConfig>();

    /// <summary>
    /// Total count of configurations matching the filter criteria.
    /// </summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>
    /// The last configuration ID returned in the list.
    /// </summary>
    [JsonProperty("last")]
    public string? Last { get; set; }
}

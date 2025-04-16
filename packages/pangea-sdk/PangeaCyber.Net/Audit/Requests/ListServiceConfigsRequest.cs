using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Request to list service configurations.
/// </summary>
public class ListServiceConfigsRequest : BaseRequest
{
    /// <summary>
    /// Filter criteria for service config queries.
    /// </summary>
    [JsonProperty("filter")]
    public ServiceConfigFilter? Filter { get; set; }

    /// <summary>
    /// Reflected value from a previous response to obtain the next page of results.
    /// </summary>
    [JsonProperty("last")]
    public string? Last { get; set; }

    /// <summary>
    /// Order results asc(ending) or desc(ending).
    /// </summary>
    [JsonProperty("order")]
    public string? Order { get; set; }

    /// <summary>
    /// Which field to order results by.
    /// </summary>
    [JsonProperty("order_by")]
    public string? OrderBy { get; set; }

    /// <summary>
    /// Maximum results to include in the response.
    /// </summary>
    [JsonProperty("size")]
    public int? Size { get; set; }
}

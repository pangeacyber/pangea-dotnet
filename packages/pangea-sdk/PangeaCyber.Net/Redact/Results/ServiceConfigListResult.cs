using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

/// <summary>
/// Result of a service config list operation.
/// </summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ServiceConfigListResult
{
    /// <summary>
    /// The total number of service configs matched by the list request.
    /// </summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>
    /// Used to fetch the next page of the current listing when provided in a repeated request's last parameter.
    /// </summary>
    [JsonProperty("last")]
    public string? Last { get; set; }

    /// <summary>
    /// List of service configs.
    /// </summary>
    [JsonProperty("items")]
    public IList<ServiceConfig>? Items { get; set; }
}

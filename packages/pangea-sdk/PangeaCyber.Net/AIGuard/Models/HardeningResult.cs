using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class HardeningResult
{
    /// <summary>
    /// The action taken by this Detector
    /// </summary>
    /// <value>The action taken by this Detector</value>
    public string? Action { get; set; } = null;

    /// <summary>
    /// Descriptive information about the hardening detector execution
    /// </summary>
    /// <value>Descriptive information about the hardening detector execution</value>
    public string? Message { get; set; } = null;

    /// <summary>
    /// Number of tokens counted in the last user prompt
    /// </summary>
    /// <value>Number of tokens counted in the last user prompt</value>
    public decimal? TokenCount { get; set; } = null;
}

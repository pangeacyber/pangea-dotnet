using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Response from an analyzer.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AnalyzerResponse
{
    /// <summary>The analyzer name.</summary>
    public required string Analyzer { get; set; }

    /// <summary>The confidence score.</summary>
    public float Confidence { get; set; }
}

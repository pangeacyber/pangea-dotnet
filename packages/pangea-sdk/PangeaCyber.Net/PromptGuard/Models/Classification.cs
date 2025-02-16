using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Models;

/// <summary>Classification.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Classification
{
    /// <summary>Classification category</summary>
    public string Category { get; set; } = default!;

    /// <summary>Classification detection result</summary>
    public bool Detected { get; set; } = default!;

    /// <summary>Confidence score for the classification</summary>
    public double Confidence { get; set; } = default!;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Results;

/// <summary>Guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardResult
{
    /// <summary>Prompt injection detected.</summary>
    public bool Detected { get; set; }

    /// <summary>Prompt injection type.</summary>
    public string? Type { get; set; }

    /// <summary>Prompt injection detector.</summary>
    public string? Detector { get; set; }

    /// <summary>Confidence.</summary>
    public int Confidence { get; set; }
}

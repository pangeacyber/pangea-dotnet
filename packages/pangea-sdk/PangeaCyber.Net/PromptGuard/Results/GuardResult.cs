using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Results;

/// <summary>Guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardResult
{
    /// <summary>Prompt injection detected.</summary>
    public bool PromptInjectionDetected { get; set; }

    /// <summary>Prompt injection type.</summary>
    public string? PromptInjectionType { get; set; }

    /// <summary>Prompt injection detector.</summary>
    public string? PromptInjectionDetector { get; set; }
}

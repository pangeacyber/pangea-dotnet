using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Container for all TextGuard detector results.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardDetectors
{
    /// <summary>Prompt injection detection results.</summary>
    public TextGuardDetector<PromptInjectionResult>? PromptInjection { get; set; }

    /// <summary>PII entity detection results.</summary>
    public TextGuardDetector<PiiEntityResult>? PiiEntity { get; set; }

    /// <summary>Malicious entity detection results.</summary>
    public TextGuardDetector<MaliciousEntityResult>? MaliciousEntity { get; set; }
}

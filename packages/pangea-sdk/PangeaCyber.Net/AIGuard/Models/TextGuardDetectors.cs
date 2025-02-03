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

    /// <summary>Secrets detection</summary>
    public TextGuardDetector<SecretsEntityResult>? SecretsDetection { get; set; }

    /// <summary>Profanity and toxicity</summary>
    public TextGuardDetector<object>? ProfanityAndToxicity { get; set; }

    /// <summary>Custom entity</summary>
    public TextGuardDetector<object>? CustomEntity { get; set; }

    /// <summary>Language detection</summary>
    public TextGuardDetector<LanguageDetectionResult>? LanguageDetection { get; set; }

    /// <summary>Code detection</summary>
    public TextGuardDetector<CodeDetectionResult>? CodeDetection { get; set; }
}

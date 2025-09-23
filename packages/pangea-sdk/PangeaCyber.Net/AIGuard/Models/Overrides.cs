using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Overrides
{
    /// <summary>Bypass existing Recipe content and create an on-the-fly Recipe.</summary>
    public bool? IgnoreRecipe { get; set; }

    /// <summary>Code detection overrides.</summary>
    public CodeDetectionOverride? CodeDetection { get; set; }

    /// <summary>Competitors overrides.</summary>
    public CompetitorsOverride? Competitors { get; set; }

    /// <summary>Gibberish overrides.</summary>
    public GibberishOverride? Gibberish { get; set; }

    /// <summary>Image overrides.</summary>
    public ImageOverride? Image { get; set; }

    /// <summary>Language detection overrides.</summary>
    public LanguageDetectionOverride? LanguageDetection { get; set; }

    /// <summary>Malicious entity overrides.</summary>
    public MaliciousEntityOverride? MaliciousEntity { get; set; }

    /// <summary>PII entity overrides.</summary>
    public PiiEntityOverride? PiiEntity { get; set; }

    /// <summary>Prompt injection overrides.</summary>
    public PromptInjectionOverride? PromptInjection { get; set; }

    /// <summary>Roleplay overrides.</summary>
    public RoleplayOverride? Roleplay { get; set; }

    /// <summary>Secrets detection overrides.</summary>
    public SecretsDetectionOverride? SecretsDetection { get; set; }

    /// <summary>Self harm overrides.</summary>
    public SelfHarmOverride? SelfHarm { get; set; }

    /// <summary>Sentiment overrides.</summary>
    public SentimentOverride? Sentiment { get; set; }

    /// <summary>Topic detection overrides.</summary>
    public TopicDetectionOverride? TopicDetection { get; set; }
}

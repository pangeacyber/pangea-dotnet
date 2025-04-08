using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Sentiment detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SentimentOverride
{
    /// <summary>Whether sentiment detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action to take on detection.</summary>
    public PromptInjectionAction? Action { get; set; }

    /// <summary>Detection threshold.</summary>
    public float? Threshold { get; set; }
}

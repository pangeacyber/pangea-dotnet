using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Self harm detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SelfHarmOverride
{
    /// <summary>Whether self harm detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action to take on detection.</summary>
    public PromptInjectionAction? Action { get; set; }

    /// <summary>Detection threshold.</summary>
    public float? Threshold { get; set; }
}

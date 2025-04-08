using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Prompt injection detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class PromptInjectionOverride
{
    /// <summary>Whether prompt injection detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action to take on detection.</summary>
    public PromptInjectionAction? Action { get; set; }
}

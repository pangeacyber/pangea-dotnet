using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Language detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class LanguageDetectionOverride
{
    /// <summary>Whether language detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>List of languages to allow.</summary>
    public List<string>? Allow { get; set; }

    /// <summary>List of languages to block.</summary>
    public List<string>? Block { get; set; }

    /// <summary>List of languages to report.</summary>
    public List<string>? Report { get; set; }
}

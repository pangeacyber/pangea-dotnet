using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Language detection result</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class LanguageDetectionResult
{
    /// <summary>Language</summary>
    public string Language { get; set; } = default!;

    /// <summary>Action</summary>
    public string Action { get; set; } = default!;
}

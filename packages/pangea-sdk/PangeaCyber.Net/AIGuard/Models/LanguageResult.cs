using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class LanguageResult
{
    /// <summary>
    /// The action taken by this Detector
    /// </summary>
    /// <value>The action taken by this Detector</value>
    public string? Action { get; set; }

    /// <summary>
    /// Gets or Sets Language
    /// </summary>
    public string? Language { get; set; }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Code detection overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class CodeDetectionOverride
{
    /// <summary>Whether code detection is disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Action to take on detection.</summary>
    public CodeDetectionAction? Action { get; set; }
}

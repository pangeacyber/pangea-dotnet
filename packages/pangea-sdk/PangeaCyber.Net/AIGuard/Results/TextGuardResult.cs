using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Results;

/// <summary>Text guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardResult
{
    /// <summary>Detectors.</summary>
    public TextGuardDetectors Detectors { get; set; } = default!;

    /// <summary>Redacted prompt.</summary>
    public string Prompt { get; set; } = default!;
}

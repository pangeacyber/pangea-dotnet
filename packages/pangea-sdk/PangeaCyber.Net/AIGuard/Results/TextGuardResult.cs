using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Results;

/// <summary>Text guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardResult
{
    /// <summary>Artifacts.</summary>
    public List<TextGuardArtifact> Artifacts { get; set; } = default!;

    /// <summary>Findings.</summary>
    public TextGuardFindings Findings { get; set; } = default!;

    /// <summary>Redacted prompt.</summary>
    public string RedactedPrompt { get; set; } = default!;

    /// <summary>Report.</summary>
    public TextGuardReport Report { get; set; } = default!;
}

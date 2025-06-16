using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Results;

/// <summary>Text guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardResult
{
    /// <summary>Updated structured prompt.</summary>
    public object? PromptMessages { get; set; }

    /// <summary>
    /// Whether or not the prompt triggered a block detection.
    /// </summary>
    public bool? Blocked { get; set; }

    /// <summary>The Recipe that was used.</summary>
    public string? Recipe { get; set; }

    /// <summary>Result of the recipe analyzing and input prompt.</summary>
    public required TextGuardDetectors Detectors { get; set; }

    /// <summary>
    /// If an FPE redaction method returned results, this will be the context
    /// passed to unredact.
    /// </summary>
    public string? FpeContext { get; set; }
}

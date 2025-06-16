using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Results;

/// <summary>Guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GuardResult
{
    /// <summary>Updated structured prompt.</summary>
    public object? Output { get; set; }

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

    /// <summary>
    /// Result of the recipe evaluating configured rules
    /// </summary>
    public object? AccessRules { get; set; }

    /// <summary>
    /// Number of tokens counted in the input
    /// </summary>
    public double? InputTokenCount { get; set; }

    /// <summary>
    /// Number of tokens counted in the output
    /// </summary>
    public double? OutputTokenCount { get; set; }

    /// <summary>
    /// Whether or not the original input was transformed.
    /// </summary>
    public bool? Transformed { get; set; }
}

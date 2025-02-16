using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Results;

/// <summary>Text guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardResult<TMessages>
{
    /// <summary>Updated prompt text, if applicable.</summary>
    public string? PromptText { get; set; }

    /// <summary>Updated structured prompt, if applicable.</summary>
    public TMessages? PromptMessages { get; set; }

    /// <summary>Whether or not the prompt triggered a block detection.</summary>
    public bool Blocked { get; set; }

    /// <summary>The Recipe that was used.</summary>
    public string Recipe { get; set; } = default!;

    /// <summary>Result of the recipe analyzing and input prompt.</summary>
    public TextGuardDetectors Detectors { get; set; } = default!;

    /// <summary>If an FPE redaction method returned results, this will be the context passed to unredact.</summary>
    public string? FpeContext { get; set; }
}

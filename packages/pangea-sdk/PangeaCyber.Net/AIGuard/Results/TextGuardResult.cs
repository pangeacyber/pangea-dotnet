using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AIGuard.Models;

namespace PangeaCyber.Net.AIGuard.Results;

/// <summary>Text guard result.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardResult<TMessages>
{
    /// <summary>Result of the recipe analyzing and input prompt.</summary>
    public TextGuardDetectors Detectors { get; set; } = default!;

    /// <summary>Updated prompt text, if applicable.</summary>
    public string? PromptText { get; set; }

    /// <summary>Updated structured prompt, if applicable.</summary>
    public TMessages? PromptMessages { get; set; }

    /// <summary>Blocked</summary>
    public bool Blocked { get; set; }
}

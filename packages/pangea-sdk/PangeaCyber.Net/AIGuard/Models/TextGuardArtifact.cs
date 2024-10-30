using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Text guard artifact.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardArtifact
{
    /// <summary>Defanged.</summary>
    public bool Defanged { get; set; }

    /// <summary>End.</summary>
    public int End { get; set; }

    /// <summary>Start.</summary>
    public int Start { get; set; }

    /// <summary>Type.</summary>
    public string Type { get; set; } = default!;

    /// <summary>Value.</summary>
    public string Value { get; set; } = default!;

    /// <summary>
    /// The verdict, given by the Pangea service, for the indicator.
    /// </summary>
    public string Verdict { get; set; } = default!;
}

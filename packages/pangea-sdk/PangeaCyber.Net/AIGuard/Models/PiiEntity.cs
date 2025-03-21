using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Represents a PII (Personally Identifiable Information) entity.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class PiiEntity
{
    /// <summary>The type of PII entity.</summary>
    public string Type { get; set; } = default!;

    /// <summary>The value of the PII entity.</summary>
    public string Value { get; set; } = default!;

    /// <summary>Action</summary>
    public string Action { get; set; } = default!;

    /// <summary>The starting position of the entity in the text.</summary>
    public int? StartPos { get; set; }
}

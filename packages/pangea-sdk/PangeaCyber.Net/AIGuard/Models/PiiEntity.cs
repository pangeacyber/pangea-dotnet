using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Represents a PII (Personally Identifiable Information) entity.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class PiiEntity
{
    /// <summary>The type of PII entity.</summary>
    public required string Type { get; set; }

    /// <summary>The value of the PII entity.</summary>
    public required string Value { get; set; }

    /// <summary>Action</summary>
    public required string Action { get; set; }

    /// <summary>The starting position of the entity in the text.</summary>
    public int? StartPos { get; set; }
}

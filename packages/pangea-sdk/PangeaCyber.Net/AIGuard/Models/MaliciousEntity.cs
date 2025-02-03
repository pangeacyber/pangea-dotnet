using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Represents a malicious entity found in the text.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class MaliciousEntity
{
    /// <summary>The type of malicious entity.</summary>
    public string Type { get; set; } = default!;

    /// <summary>The value of the malicious entity.</summary>
    public string Value { get; set; } = default!;

    /// <summary>Action</summary>
    public DetectorAction Action { get; set; }

    /// <summary>The starting position of the entity in the text.</summary>
    public int? StartPos { get; set; }

    /// <summary>Raw data associated with the analysis.</summary>
    public Dictionary<string, object>? Raw { get; set; }
}

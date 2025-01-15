using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Result containing PII entities.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class PiiEntityResult
{
    /// <summary>List of PII entities found.</summary>
    public List<PiiEntity> Entities { get; set; } = default!;
}

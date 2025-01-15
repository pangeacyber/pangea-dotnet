using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Result containing malicious entities.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class MaliciousEntityResult
{
    /// <summary>List of malicious entities found.</summary>
    public List<MaliciousEntity> Entities { get; set; } = default!;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Secrets entity result</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SecretsEntityResult
{
    /// <summary>Entities</summary>
    public required List<SecretsEntity> Entities { get; set; }
}

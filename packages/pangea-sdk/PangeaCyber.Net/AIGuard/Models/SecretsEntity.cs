using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Secrets entity</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SecretsEntity
{
    /// <summary>Type</summary>
    public required string Type { get; set; }

    /// <summary>Value</summary>
    public required string Value { get; set; }

    /// <summary>Action</summary>
    public required string Action { get; set; }

    /// <summary>Start position</summary>
    public int? StartPos { get; set; }

    /// <summary>Redacted value</summary>
    public required string RedactedValue { get; set; }
}

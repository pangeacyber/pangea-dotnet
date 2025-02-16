using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Secrets entity</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SecretsEntity
{
    /// <summary>Type</summary>
    public string Type { get; set; } = default!;

    /// <summary>Value</summary>
    public string Value { get; set; } = default!;

    /// <summary>Action</summary>
    public string Action { get; set; } = default!;

    /// <summary>Start position</summary>
    public int? StartPos { get; set; }

    /// <summary>Redacted value</summary>
    public string RedactedValue { get; set; } = default!;
}

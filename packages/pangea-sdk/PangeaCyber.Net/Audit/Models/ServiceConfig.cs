using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Configuration for the Audit service.
/// </summary>
public class ServiceConfig
{
    /// <summary>
    /// Version of the configuration.
    /// </summary>
    [JsonProperty("version")]
    public int Version { get; set; }

    /// <summary>
    /// Unique identifier for the configuration.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Timestamp when the configuration was created.
    /// </summary>
    [JsonProperty("created_at")]
    public string CreatedAt { get; set; } = default!;

    /// <summary>
    /// Timestamp when the configuration was last updated.
    /// </summary>
    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; } = default!;

    /// <summary>
    /// Retention window for audit logs in days.
    /// </summary>
    [JsonProperty("retention_window")]
    public int? RetentionWindow { get; set; }

    /// <summary>
    /// Retention window for audit logs in days for tamper-proof logs.
    /// </summary>
    [JsonProperty("tamper_proof_retention_window")]
    public int? TamperProofRetentionWindow { get; set; }

    /// <summary>
    /// Retention window for audit logs in days for malformed logs.
    /// </summary>
    [JsonProperty("malformed_retention_window")]
    public int? MalformedRetentionWindow { get; set; }

    /// <summary>
    /// Whether client signing is enabled.
    /// </summary>
    [JsonProperty("client_signable")]
    public bool? ClientSignable { get; set; }

    /// <summary>
    /// Whether malformed logs should be saved.
    /// </summary>
    [JsonProperty("save_malformed")]
    public bool? SaveMalformed { get; set; }

    /// <summary>
    /// Whether tamper-proofing is enabled.
    /// </summary>
    [JsonProperty("tamper_proofing")]
    public bool? TamperProofing { get; set; }

    /// <summary>
    /// Forwarding configuration for audit logs.
    /// </summary>
    [JsonProperty("forwarding_config")]
    public ForwardingConfiguration? ForwardingConfig { get; set; }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// A description of acceptable fields for an audit log.
/// </summary>
public sealed class AuditSchema
{
    /// <summary>
    /// If true, records contain fields to support client/vault signing.
    /// </summary>
    [JsonProperty("client_signable")]
    public bool? ClientSignable { get; set; }

    /// <summary>
    /// Save (or reject) malformed AuditEvents.
    /// </summary>
    [JsonProperty("save_malformed")]
    public string? SaveMalformed { get; set; }

    /// <summary>
    /// If true, records contain fields to support tamper-proofing.
    /// </summary>
    [JsonProperty("tamper_proofing")]
    public bool? TamperProofing { get; set; }

    /// <summary>
    /// List of field definitions.
    /// </summary>
    [JsonProperty("fields")]
    public List<AuditSchemaField>? Fields { get; set; }
}

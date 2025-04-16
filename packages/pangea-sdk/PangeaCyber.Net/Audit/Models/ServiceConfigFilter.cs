using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Filter criteria for listing service configurations.
/// </summary>
public sealed class ServiceConfigFilter
{
    /// <summary>
    /// Filter by configuration version.
    /// </summary>
    [JsonProperty("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Filter by configuration ID.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Filter by creation timestamp.
    /// </summary>
    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Filter by last update timestamp.
    /// </summary>
    [JsonProperty("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Filter by retention window in days.
    /// </summary>
    [JsonProperty("retention_window")]
    public int? RetentionWindow { get; set; }

    /// <summary>
    /// Filter by tamper-proof retention window in days.
    /// </summary>
    [JsonProperty("tamper_proof_retention_window")]
    public int? TamperProofRetentionWindow { get; set; }

    /// <summary>
    /// Filter by malformed retention window in days.
    /// </summary>
    [JsonProperty("malformed_retention_window")]
    public int? MalformedRetentionWindow { get; set; }

    /// <summary>
    /// Filter by client signing enabled status.
    /// </summary>
    [JsonProperty("client_signable")]
    public bool? ClientSignable { get; set; }

    /// <summary>
    /// Filter by save malformed status.
    /// </summary>
    [JsonProperty("save_malformed")]
    public bool? SaveMalformed { get; set; }

    /// <summary>
    /// Filter by tamper-proofing enabled status.
    /// </summary>
    [JsonProperty("tamper_proofing")]
    public bool? TamperProofing { get; set; }
}

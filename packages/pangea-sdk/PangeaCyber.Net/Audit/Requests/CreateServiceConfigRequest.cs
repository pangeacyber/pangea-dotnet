using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Request to create a service configuration.
/// </summary>
public class CreateServiceConfigRequest : BaseRequest
{
    /// <summary>
    /// Version number
    /// </summary>
    [JsonProperty("version")]
    public int Version { get; set; }

    /// <summary>
    /// Configuration name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Audit log field configuration. Only settable at create time.
    /// </summary>
    [JsonProperty("schema")]
    public AuditSchema? Schema { get; set; }

    /// <summary>
    /// Retention window for logs in cold storage. Deleted afterwards.
    /// </summary>
    [JsonProperty("cold_storage")]
    public string? ColdStorage { get; set; }

    /// <summary>
    /// Retention window for logs in hot storage. Migrated to warm, cold, or deleted afterwards.
    /// </summary>
    [JsonProperty("hot_storage")]
    public string? HotStorage { get; set; }

    /// <summary>
    /// Retention window for logs in warm storage. Migrated to cold or deleted afterwards.
    /// </summary>
    [JsonProperty("warm_storage")]
    public string? WarmStorage { get; set; }

    /// <summary>
    /// A redact service config that will be used to redact PII from logs.
    /// </summary>
    [JsonProperty("redact_service_config_id")]
    public string? RedactServiceConfigId { get; set; }

    /// <summary>
    /// A vault service config that will be used to sign logs.
    /// </summary>
    [JsonProperty("vault_service_config_id")]
    public string? VaultServiceConfigId { get; set; }

    /// <summary>
    /// ID of the Vault key used for signing. If missing, use a default Audit key.
    /// </summary>
    [JsonProperty("vault_key_id")]
    public string? VaultKeyId { get; set; }

    /// <summary>
    /// Enable/disable event signing.
    /// </summary>
    [JsonProperty("vault_sign")]
    public bool? VaultSign { get; set; }

    /// <summary>
    /// Configuration for forwarding audit logs to external systems.
    /// </summary>
    [JsonProperty("forwarding_configuration")]
    public ForwardingConfiguration? ForwardingConfiguration { get; set; }
}

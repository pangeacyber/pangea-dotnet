using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit;

/// <summary>
/// Configuration for forwarding audit logs to external systems.
/// </summary>
public class ForwardingConfiguration
{
    /// <summary>
    /// Type of forwarding configuration.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = default!;

    /// <summary>
    /// Whether forwarding is enabled.
    /// </summary>
    [JsonProperty("forwarding_enabled")]
    public bool? ForwardingEnabled { get; set; }

    /// <summary>
    /// URL where events will be written to. Must use HTTPS.
    /// </summary>
    [JsonProperty("event_url")]
    public string? EventUrl { get; set; }

    /// <summary>
    /// If indexer acknowledgement is required, this must be provided along with a 'channelId'.
    /// </summary>
    [JsonProperty("ack_url")]
    public string? AckUrl { get; set; }

    /// <summary>
    /// An optional splunk channel included in each request if indexer acknowledgement is required.
    /// </summary>
    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    /// <summary>
    /// Public certificate if a self signed TLS cert is being used.
    /// </summary>
    [JsonProperty("public_cert")]
    public string? PublicCert { get; set; }

    /// <summary>
    /// Optional splunk index passed in the record bodies.
    /// </summary>
    [JsonProperty("index")]
    public string? Index { get; set; }

    /// <summary>
    /// The vault config used to store the HEC token.
    /// </summary>
    [JsonProperty("vault_config_id")]
    public string? VaultConfigId { get; set; }

    /// <summary>
    /// The secret ID where the HEC token is stored in vault.
    /// </summary>
    [JsonProperty("vault_secret_id")]
    public string? VaultSecretId { get; set; }
}

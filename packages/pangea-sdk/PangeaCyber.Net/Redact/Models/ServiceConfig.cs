using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ServiceConfig
{
    [JsonProperty(Required = Required.Always)]
    public string Version { get; set; } = null!;

    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; } = null!;

    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; } = null!;

    [JsonProperty(Required = Required.Always)]
    public string UpdatedAt { get; set; } = null!;

    [JsonProperty(Required = Required.Always)]
    public List<string> EnabledRules { get; set; } = null!;

    /// <summary>
    /// Always run service config enabled rules across all redact calls regardless of flags?
    /// </summary>
    public bool? EnforceEnabledRules { get; set; }

    public IDictionary<string, Redaction>? Redactions { get; set; } = default!;

    /// <summary>
    /// Service config used to create the secret
    /// </summary>
    public string? VaultServiceConfigId { get; set; }

    /// <summary>
    /// Pangea only allows hashing to be done using a salt value to prevent brute-force attacks.
    /// </summary>
    public string? SaltVaultSecretId { get; set; }

    /// <summary>
    /// The ID of the key used by FF3 Encryption algorithms for FPE.
    /// </summary>
    public string? FpeVaultSecretId { get; set; }

    public IDictionary<string, Rule>? Rules { get; set; }
    public IDictionary<string, Ruleset>? Rulesets { get; set; }
    public IList<string>? SupportedLanguages { get; set; }
}

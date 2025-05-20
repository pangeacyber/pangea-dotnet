using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ConnectionsConfig
{
    public ConnectionsConfigPromptGuard PromptGuard { get; set; } = default!;
    public ConnectionsConfigIpIntel IpIntel { get; set; } = default!;
    public ConnectionsConfigUserIntel UserIntel { get; set; } = default!;
    public ConnectionsConfigUrlIntel UrlIntel { get; set; } = default!;
    public ConnectionsConfigUrlIntel DomainIntel { get; set; } = default!;
    public ConnectionsConfigFileScan FileScan { get; set; } = default!;
    public ConnectionsConfigRedact Redact { get; set; } = default!;
    public ConnectionsConfigVault Vault { get; set; } = default!;
    public ConnectionsConfigLingua Lingua { get; set; } = default!;
    public ConnectionsConfigCode Code { get; set; } = default!;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AuditDataActivityConfig
{
    public bool Enabled { get; set; }
    public string AuditServiceConfigId { get; set; } = default!;
    public AuditDataActivityConfigAreas Areas { get; set; } = default!;
}

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Models;

[DataContract]
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AuditDataActivityConfig
{
    [DataMember(Name = "enabled", IsRequired = true)]
    public bool Enabled { get; set; }

    [DataMember(Name = "audit_service_config_id", IsRequired = true)]
    public string AuditServiceConfigId { get; set; } = default!;

    [DataMember(Name = "areas", IsRequired = true)]
    public AuditDataActivityConfigAreas Areas { get; set; } = default!;
}

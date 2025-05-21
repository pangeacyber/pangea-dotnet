using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Models;

[DataContract]
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AuditDataActivityConfigAreas
{
    [DataMember(Name = "malicious_prompt")]
    public bool MaliciousPrompt { get; set; }

    [DataMember(Name = "benign_prompt")]
    public bool BenignPrompt { get; set; }
}

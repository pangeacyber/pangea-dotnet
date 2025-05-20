using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[DataContract]
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AuditDataActivityConfigAreas
{
    [DataMember(Name = "text_guard", IsRequired = true, EmitDefaultValue = true)]
    public bool TextGuard { get; set; }
}

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ServiceConfig
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public AuditDataActivityConfig AuditDataActivity { get; set; } = default!;
    public ConnectionsConfig Connections { get; set; } = default!;
    public object Recipes { get; set; } = default!;
}

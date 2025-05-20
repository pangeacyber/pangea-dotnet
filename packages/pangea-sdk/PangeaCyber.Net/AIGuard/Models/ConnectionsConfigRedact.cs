using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public partial class ConnectionsConfigRedact
{
    public bool Enabled { get; set; }
    public string ConfigId { get; set; } = default!;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public partial class ConnectionsConfigUserIntel
{
    public bool Enabled { get; set; }
    public string ConfigId { get; set; } = default!;
    public string BreachProvider { get; set; } = default!;
}

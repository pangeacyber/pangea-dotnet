using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class MultimodalMessage
{
    public required string Role { get; set; }

    public required IList<MultimodalContent> Content { get; set; }
}

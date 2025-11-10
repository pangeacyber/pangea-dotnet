using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class RedactEntityResult
{
    /// <summary> Detected redaction rules.</summary>
    public required List<RedactEntityResultItem> Entities { get; set; }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class RedactEntityResultItem
    {
        /// <summary>The action taken on this Entity</summary>
        public required string Action { get; set; }
        public required string Type { get; set; }
        public required string Value { get; set; }
        public int StartPos { get; set; }
    }
}

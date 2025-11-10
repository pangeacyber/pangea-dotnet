using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TopicResult
{
    /// <summary>The action taken by this Detector</summary>
    public string? Action { get; set; } = null;

    /// <summary>List of topics detected</summary>
    public List<TopicResultItem>? Topics { get; set; } = null;

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class TopicResultItem
    {
        public required string Topic { get; set; }
        public decimal Confidence { get; set; }
    }
}

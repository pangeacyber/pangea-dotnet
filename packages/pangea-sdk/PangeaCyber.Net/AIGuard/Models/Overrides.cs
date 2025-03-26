using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Overrides.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Overrides
{
    /// <summary>Topic detection overrides.</summary>
    public TopicDetectionOverride? TopicDetection { get; set; }
}

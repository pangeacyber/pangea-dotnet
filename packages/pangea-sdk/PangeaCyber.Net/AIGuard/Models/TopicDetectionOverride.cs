using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Topic detection override.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TopicDetectionOverride
{
    /// <summary>Disabled.</summary>
    public bool? Disabled { get; set; }

    /// <summary>Block list.</summary>
    public List<string>? BlockList { get; set; }
}

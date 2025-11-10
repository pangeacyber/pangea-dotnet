using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class SingleEntityResult
{
    /// <summary>The action taken by this Detector</summary>
    public string? Action { get; set; } = null;

    /// <summary>Detected entities.</summary>
    public List<string>? Entities { get; set; } = null;
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Response from an analyzer.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class MultimodalContent
{
    public abstract string Type { get; }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Generic detector result for TextGuard.</summary>
/// <typeparam name="T">The type of the detection data.</typeparam>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextGuardDetector<T>
{
    /// <summary>Whether something was detected.</summary>
    public bool Detected { get; set; }

    /// <summary>The detection data if something was detected.</summary>
    public T? Data { get; set; }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Matcher
{
    public string MatchType { get; set; } = default!;
    public string? MatchValue { get; set; } = default!;
    public float? MatchScore { get; set; } = default!;
}

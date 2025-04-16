using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Rule
{
    [JsonProperty(Required = Required.Always)]
    public string EntityName { get; set; } = null!;

    [JsonProperty(Required = Required.Always)]
    public string Ruleset { get; set; } = null!;

    public float? MatchThreshold { get; set; }
    public IList<string>? ContextValues { get; set; }
    public IList<string>? NegativeContextValues { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Ruleset
{
    [JsonProperty("name")]
    public string? Name { get; set; } = default!;

    [JsonProperty("description")]
    public string? Description { get; set; } = default!;

    [JsonProperty("rules")]
    public IList<string>? Rules { get; set; } = default!;
}

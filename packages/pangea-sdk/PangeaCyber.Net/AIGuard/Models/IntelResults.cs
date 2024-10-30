using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Intel results.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class IntelResults
{
    /// <summary>
    /// The categories that apply to this indicator as determined by the provider.
    /// </summary>
    [JsonProperty("category")]
    public IList<string> Category { get; set; } = default!;

    /// <summary>
    /// The score, given by the Pangea service, for the indicator.
    /// </summary>
    [JsonProperty("score")]
    public double Score { get; set; } = default!;

    /// <summary>
    /// The verdict for the indicator.
    /// </summary>
    [JsonProperty("verdict")]
    public string Verdict { get; set; } = default!;
}

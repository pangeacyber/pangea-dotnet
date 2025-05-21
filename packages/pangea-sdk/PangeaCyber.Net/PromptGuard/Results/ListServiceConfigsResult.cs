using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.PromptGuard.Models;

namespace PangeaCyber.Net.PromptGuard.Results;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ListServiceConfigsResult
{
    /// <summary>
    /// The total number of service configs matched by the list request.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int Count { get; set; }

    /// <summary>
    /// Used to fetch the next page of the current listing when provided in a repeated request's last parameter.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Last { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public List<ServiceConfig> Items { get; set; } = default!;
}

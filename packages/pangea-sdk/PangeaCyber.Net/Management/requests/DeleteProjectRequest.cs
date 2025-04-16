using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Management;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class DeleteProjectRequest : BaseRequest
{
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; } = default!;
}

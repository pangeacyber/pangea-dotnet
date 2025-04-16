using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.Redact;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GetServiceConfigRequest : BaseRequest
{
    /// <summary>Config ID</summary>
    public string Id { get; set; } = default!;
}

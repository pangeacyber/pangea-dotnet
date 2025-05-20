using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GetServiceConfigRequest : BaseRequest
{
    public string Id { get; set; }

    /// <summary>Constructor</summary>
    public GetServiceConfigRequest(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}

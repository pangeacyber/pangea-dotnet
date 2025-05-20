using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class DeleteServiceConfigRequest : BaseRequest
{
    public string Id { get; set; }

    /// <summary>Constructor</summary>
    public DeleteServiceConfigRequest(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}

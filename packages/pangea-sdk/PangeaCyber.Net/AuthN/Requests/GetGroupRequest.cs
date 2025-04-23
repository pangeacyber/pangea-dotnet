using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>GetGroupRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GetGroupRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;
}

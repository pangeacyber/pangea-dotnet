using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>DeleteGroupRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class DeleteGroupRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;
}

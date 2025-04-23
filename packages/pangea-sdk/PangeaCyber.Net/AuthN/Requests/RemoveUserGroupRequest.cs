using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>RemoveUserGroupRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class RemoveUserGroupRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;

    /// <summary>GroupId</summary>
    public string GroupId { get; set; } = default!;
}

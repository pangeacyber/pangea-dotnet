using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>ListUserGroupsRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ListUserGroupsRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;
}

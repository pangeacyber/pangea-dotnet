using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>AssignUserGroupRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class AssignUserGroupRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;

    /// <summary>GroupIds</summary>
    public IReadOnlyList<string> GroupIds { get; set; } = default!;
}

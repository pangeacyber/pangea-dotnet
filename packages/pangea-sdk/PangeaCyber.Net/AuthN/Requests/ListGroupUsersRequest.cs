using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>ListGroupUsersRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ListGroupUsersRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;

    /// <summary>Last</summary>
    public string? Last { get; set; }

    /// <summary>Size</summary>
    public int? Size { get; set; }
}

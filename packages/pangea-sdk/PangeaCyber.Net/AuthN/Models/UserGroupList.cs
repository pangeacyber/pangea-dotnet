using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Models;

/// <summary>UserGroupList</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class UserGroupList
{
    /// <summary>Users</summary>
    public IReadOnlyList<User> Users { get; set; } = default!;

    /// <summary>Count</summary>
    public int Count { get; set; }

    /// <summary>Last</summary>
    public string? Last { get; set; }
}

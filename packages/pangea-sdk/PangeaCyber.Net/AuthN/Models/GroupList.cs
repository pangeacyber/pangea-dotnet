using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Models;

/// <summary>GroupList</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GroupList
{
    /// <summary>List of matching groups</summary>
    public IReadOnlyList<GroupInfo> Groups { get; set; } = default!;

    /// <summary>Count</summary>
    public int Count { get; set; }

    /// <summary>Last</summary>
    public string? Last { get; set; }
}

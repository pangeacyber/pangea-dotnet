using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>ListGroupsRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ListGroupsRequest : BaseRequest
{
    /// <summary>Filter</summary>
    public GroupsFilter? Filter { get; set; }

    /// <summary>Last</summary>
    public string? Last { get; set; }

    /// <summary>Order</summary>
    public string? Order { get; set; }

    /// <summary>OrderBy</summary>
    public string? OrderBy { get; set; }

    /// <summary>Size</summary>
    public int? Size { get; set; }
}

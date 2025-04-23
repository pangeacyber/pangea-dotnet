using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Models;

/// <summary>GroupInfo</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GroupInfo
{
    /// <summary>ID</summary>
    public string Id { get; set; } = default!;

    /// <summary>Name</summary>
    public string Name { get; set; } = default!;

    /// <summary>Type</summary>
    public string Type { get; set; } = default!;

    /// <summary>Description</summary>
    public string? Description { get; set; }

    /// <summary>Attributes</summary>
    public IReadOnlyDictionary<string, string>? Attributes { get; set; }

    /// <summary>Created At</summary>
    public string? CreatedAt { get; set; }

    /// <summary>Updated At</summary>
    public string? UpdatedAt { get; set; }
}

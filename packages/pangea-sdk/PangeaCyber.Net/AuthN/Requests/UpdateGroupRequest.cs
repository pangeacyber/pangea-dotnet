using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>UpdateGroupRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class UpdateGroupRequest : BaseRequest
{
    /// <summary>Id</summary>
    public string Id { get; set; } = default!;

    /// <summary>Name</summary>
    public string? Name { get; set; }

    /// <summary>Description</summary>
    public string? Description { get; set; }

    /// <summary>Type</summary>
    public string? Type { get; set; }

    /// <summary>Attributes</summary>
    public IReadOnlyDictionary<string, string>? Attributes { get; set; }
}

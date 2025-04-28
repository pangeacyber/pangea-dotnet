using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AuthN.Requests;

/// <summary>CreateGroupRequest</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class CreateGroupRequest : BaseRequest
{
    /// <summary>Name</summary>
    public string Name { get; set; } = default!;

    /// <summary>Type</summary>
    public string Type { get; set; } = default!;

    /// <summary>Description</summary>
    public string? Description { get; set; }

    /// <summary>Attributes</summary>
    public IReadOnlyDictionary<string, string>? Attributes { get; set; }
}

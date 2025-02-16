using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.PromptGuard.Models;

/// <summary>Message.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Message
{
    /// <summary>Role.</summary>
    public string Role { get; set; } = default!;

    /// <summary>Content.</summary>
    public string Content { get; set; } = default!;
}

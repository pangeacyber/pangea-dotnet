using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Message.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Message
{
    /// <summary>Role.</summary>
    public required string Role { get; set; }

    /// <summary>Content.</summary>
    public required string Content { get; set; }
}

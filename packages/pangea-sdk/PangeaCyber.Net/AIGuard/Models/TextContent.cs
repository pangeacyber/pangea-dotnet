using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Response from an analyzer.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class TextContent : MultimodalContent
{
    public override string Type { get; } = "text";

    public required string Text { get; set; }
}

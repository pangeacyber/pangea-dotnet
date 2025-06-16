using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Response from an analyzer.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class ImageContent : MultimodalContent
{
    public override string Type { get; } = "image";

    public required string ImageSrc { get; set; }
}

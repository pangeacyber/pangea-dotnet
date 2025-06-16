using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Code detection result</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class CodeDetectionResult
{
    /// <summary>Language</summary>
    public required string Language { get; set; }

    /// <summary>Action</summary>
    public required string Action { get; set; }
}

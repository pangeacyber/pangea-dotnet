using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Code detection result</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class CodeDetectionResult
{
    /// <summary>Language</summary>
    public string Language { get; set; } = default!;

    /// <summary>Action</summary>
    public string Action { get; set; } = default!;
}

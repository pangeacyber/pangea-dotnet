using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PangeaCyber.Net.Redact;

namespace PangeaCyber.Net.DataGuard.Models;

/// <summary>Redact report.</summary>
[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class RedactReport
{
    /// <summary>Count.</summary>
    public int Count { get; set; } = default!;

    /// <summary>Recognizer results.</summary>
    public IList<RedactRecognizerResult> RecognizerResults { get; set; } = default!;

}

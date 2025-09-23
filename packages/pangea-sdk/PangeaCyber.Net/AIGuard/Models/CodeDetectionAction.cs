using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Action to take when code is detected.</summary>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CodeDetectionAction
{
    /// <summary>Report the detection.</summary>
    Report,

    /// <summary>Block the content.</summary>
    Block
}

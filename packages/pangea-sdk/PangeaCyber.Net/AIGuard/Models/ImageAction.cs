using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Action to take on detection.</summary>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum ImageAction
{
    /// <summary>Report the detection.</summary>
    Report,

    /// <summary>Block the content.</summary>
    Block
}

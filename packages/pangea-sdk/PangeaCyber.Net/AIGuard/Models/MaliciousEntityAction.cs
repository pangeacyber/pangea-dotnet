using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Action to take when malicious entities are detected.</summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum MaliciousEntityAction
{
    /// <summary>Report the detection.</summary>
    Report,

    /// <summary>Defang the malicious content.</summary>
    Defang,

    /// <summary>Disable malicious entity detection.</summary>
    Disabled,

    /// <summary>Block the content.</summary>
    Block
}

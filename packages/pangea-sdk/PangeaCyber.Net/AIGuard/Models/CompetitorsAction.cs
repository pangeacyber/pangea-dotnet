using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Action to take when competitors are detected.</summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum CompetitorsAction
{
    /// <summary>Report the detection.</summary>
    Report,

    /// <summary>Block the content.</summary>
    Block
}

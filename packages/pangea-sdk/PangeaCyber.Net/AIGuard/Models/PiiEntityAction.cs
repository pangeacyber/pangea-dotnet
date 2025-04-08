using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AIGuard.Models;

/// <summary>Action to take when PII entities are detected.</summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PiiEntityAction
{
    /// <summary>Disable PII detection.</summary>
    Disabled,

    /// <summary>Report the detection.</summary>
    Report,

    /// <summary>Block the content.</summary>
    Block,

    /// <summary>Mask the PII.</summary>
    Mask,

    /// <summary>Partially mask the PII.</summary>
    PartialMasking,

    /// <summary>Replace the PII.</summary>
    Replacement,

    /// <summary>Hash the PII.</summary>
    Hash,

    /// <summary>Format preserving encryption.</summary>
    Fpe
}

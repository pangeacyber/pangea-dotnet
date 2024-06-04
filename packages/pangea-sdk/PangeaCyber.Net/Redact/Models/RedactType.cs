using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Redact
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RedactType
    {
        ///
        [EnumMember(Value = "mask")]
        MASK,

        ///
        [EnumMember(Value = "partial_masking")]
        PARTIAL_MASKING,

        ///
        [EnumMember(Value = "replacement")]
        REPLACEMENT,

        ///
        [EnumMember(Value = "detect_only")]
        DETECT_ONLY,

        ///
        [EnumMember(Value = "fpe")]
        FPE,

        ///
        [EnumMember(Value = "hash")]
        HASH

    }
}

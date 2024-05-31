using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Redact
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FPEAlphabet
    {
        ///
        [EnumMember(Value = "numeric")]
        NUMERIC,

        ///
        [EnumMember(Value = "alphanumericlower")]
        ALPHANUMERICLOWER,

        ///
        [EnumMember(Value = "alphanumeric")]
        ALPHANUMERIC

    }
}

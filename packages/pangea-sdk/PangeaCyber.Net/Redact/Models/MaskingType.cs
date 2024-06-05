using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Redact
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaskingType
    {
        ///
        [EnumMember(Value = "mask")]
        MASK,

        ///
        [EnumMember(Value = "unmask")]
        UNMASK

    }
}

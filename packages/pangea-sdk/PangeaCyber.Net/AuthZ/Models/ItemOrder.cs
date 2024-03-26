using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AuthZ.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemOrder
    {
        ///
        [EnumMember(Value = "asc")]
        Asc,

        ///
        [EnumMember(Value = "desc")]
        Desc
    }
}

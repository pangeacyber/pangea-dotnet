using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ListOrder
    {
        ///
        [EnumMember(Value = "asc")]
        Ascending,

        ///
        [EnumMember(Value = "desc")]
        Descending
    }
}

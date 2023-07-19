using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemOrder
    {
        ///
        [EnumMember(Value = "asc")]
        ASC,

        ///
        [EnumMember(Value = "desc")]
        DESC
    }
}

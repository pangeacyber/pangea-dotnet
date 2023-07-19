using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        ///
        [EnumMember(Value = "asymmetric_key")]
        ASYMMETRIC_KEY,

        ///
        [EnumMember(Value = "symmetric_key")]
        SYMMETRIC_KEY,

        ///
        [EnumMember(Value = "secret")]
        SECRET
    }
}

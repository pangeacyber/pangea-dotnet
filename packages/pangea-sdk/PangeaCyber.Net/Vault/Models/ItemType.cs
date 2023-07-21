using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        ///
        [EnumMember(Value = "asymmetric_key")]
        AsymmetricKey,

        ///
        [EnumMember(Value = "symmetric_key")]
        SymmetricKey,

        ///
        [EnumMember(Value = "secret")]
        Secret
    }
}

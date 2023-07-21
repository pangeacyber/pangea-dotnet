using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KeyPurpose
    {
        ///
        [EnumMember(Value = "signing")]
        Signing,

        ///
        [EnumMember(Value = "encryption")]
        Encryption,
        
        ///
        [EnumMember(Value = "jwt")]
        JWT
    }
}

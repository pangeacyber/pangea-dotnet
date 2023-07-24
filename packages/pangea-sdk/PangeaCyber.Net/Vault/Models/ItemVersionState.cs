using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemVersionState
    {
        ///
        [EnumMember(Value = "active")]
        Active,
        
        ///
        [EnumMember(Value = "deactivated")]
        Deactivated,

        ///        
        [EnumMember(Value = "suspended")]
        Suspended,
        
        ///
        [EnumMember(Value = "compromised")]
        Compromised,
        
        ///
        [EnumMember(Value = "destroyed")]
        Destroyed

    }
}

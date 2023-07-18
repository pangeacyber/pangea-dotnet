using System.Runtime.Serialization;

namespace PangeaCyber.Net.Vault
{
    ///
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

using System.Runtime.Serialization;

namespace PangeaCyber.Net.Vault
{
    ///
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
        Jwt
    }
}

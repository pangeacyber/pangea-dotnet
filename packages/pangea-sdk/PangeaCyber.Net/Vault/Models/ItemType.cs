using System.Runtime.Serialization;

namespace PangeaCyber.Net.Vault
{
    ///
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

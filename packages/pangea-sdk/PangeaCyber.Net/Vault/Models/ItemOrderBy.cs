using System.Runtime.Serialization;

namespace PangeaCyber.Net.Vault
{
    ///
    public enum ItemOrderBy
    {
        ///
        [EnumMember(Value = "type")]
        TYPE,

        ///
        [EnumMember(Value = "created_at")]
        CREATED_AT,

        ///
        [EnumMember(Value = "destroy_at")]
        DESTROY_AT,

        ///
        [EnumMember(Value = "purpose")]
        PURPOSE,

        ///
        [EnumMember(Value = "expiration")]
        EXPIRATION,

        ///
        [EnumMember(Value = "last_rotated")]
        LAST_ROTATED,

        ///
        [EnumMember(Value = "next_rotation")]
        NEXT_ROTATION,

        ///
        [EnumMember(Value = "name")]
        NAME,

        ///
        [EnumMember(Value = "folder")]
        FOLDER,

        ///
        [EnumMember(Value = "version")]
        VERSION
    }
}

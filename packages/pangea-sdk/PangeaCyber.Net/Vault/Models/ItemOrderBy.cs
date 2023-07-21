using System.Runtime.Serialization;

namespace PangeaCyber.Net.Vault
{
    ///
    public enum ItemOrderBy
    {
        ///
        [EnumMember(Value = "type")]
        Type,

        ///
        [EnumMember(Value = "created_at")]
        CreatedAt,

        ///
        [EnumMember(Value = "destroy_at")]
        DestroyAt,

        ///
        [EnumMember(Value = "purpose")]
        Purpose,

        ///
        [EnumMember(Value = "expiration")]
        Expiration,

        ///
        [EnumMember(Value = "last_rotated")]
        LastRotated,

        ///
        [EnumMember(Value = "next_rotation")]
        NextRotation,

        ///
        [EnumMember(Value = "name")]
        Name,

        ///
        [EnumMember(Value = "folder")]
        Folder,

        ///
        [EnumMember(Value = "version")]
        Version
    }
}

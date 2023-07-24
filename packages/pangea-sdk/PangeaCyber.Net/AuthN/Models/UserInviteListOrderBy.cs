using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserInviteListOrderBy
    {
        ///
        [EnumMember(Value = "id")]
        ID,

        ///
        [EnumMember(Value = "created_at")]
        CreatedAt,

        ///
        [EnumMember(Value = "type")]
        Type,

        ///
        [EnumMember(Value = "email")]
        Email,

        ///
        [EnumMember(Value = "expire")]
        Expire,

        ///
        [EnumMember(Value = "callback")]
        Callback,

        ///
        [EnumMember(Value = "state")]
        State,

        ///
        [EnumMember(Value = "inviter")]
        Inviter,

        ///
        [EnumMember(Value = "invite_org")]
        InviteOrg
    }
}

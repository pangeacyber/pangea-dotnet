using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserListOrderBy
    {
        ///
        [EnumMember(Value = "id")]
        ID,

        ///
        [EnumMember(Value = "created_at")]
        CreatedAt,

        ///
        [EnumMember(Value = "last_login_at")]
        LastLoginAt,

        ///
        [EnumMember(Value = "email")]
        Email
    }
}

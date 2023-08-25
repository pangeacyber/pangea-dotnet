using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AgreementListOrderBy
    {
        ///
        [EnumMember(Value = "id")]
        ID,

        ///
        [EnumMember(Value = "created_at")]
        CreatedAt,

        ///
        [EnumMember(Value = "name")]
        Name,

        ///
        [EnumMember(Value = "text")]
        Text,
    }
}

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.AuthZ.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TupleOrderBy
    {
        ///
        [EnumMember(Value = "resource_type")]
        ResourceType,

        ///
        [EnumMember(Value = "resource_id")]
        ResourceID,

        ///
        [EnumMember(Value = "relation")]
        Relation,

        ///
        [EnumMember(Value = "subject_type")]
        SubjectType,

        ///
        [EnumMember(Value = "subject_id")]
        SubjectID,

        ///
        [EnumMember(Value = "subject_action")]
        SubjectAction
    }
}

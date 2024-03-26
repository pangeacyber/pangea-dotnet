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
        [EnumMember(Value = "resource_namespace")]
        ResourceNamespace,

        ///
        [EnumMember(Value = "resource_id")]
        ResourceID,

        ///
        [EnumMember(Value = "relation")]
        Relation,

        ///
        [EnumMember(Value = "subject_namespace")]
        SubjectNamespace,

        ///
        [EnumMember(Value = "subject_id")]
        SubjectID,

        ///
        [EnumMember(Value = "subject_action")]
        SubjectAction
    }

}

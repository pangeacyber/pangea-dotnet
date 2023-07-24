using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum FlowType
    {
        ///
        [EnumMember(Value = "signin")]
        Signin,

        ///
        [EnumMember(Value = "signup")]
        Signup
    }
}

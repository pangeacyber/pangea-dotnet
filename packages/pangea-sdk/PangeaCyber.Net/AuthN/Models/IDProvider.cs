using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum IDProvider
    {
        ///
        [EnumMember(Value = "facebook")]
        Facebook,

        ///
        [EnumMember(Value = "github")]
        Github,

        ///
        [EnumMember(Value = "google")]
        Google,

        ///
        [EnumMember(Value = "microsoftonline")]
        Microsoft,

        ///
        [EnumMember(Value = "password")]
        Password
    }
}

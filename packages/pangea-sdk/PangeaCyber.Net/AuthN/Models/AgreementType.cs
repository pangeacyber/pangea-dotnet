using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AgreementType
    {
        ///
        [EnumMember(Value = "eula")]
        EULA,

        ///
        [EnumMember(Value = "privacy_policy")]
        PrivacyPolicy,

    }
}

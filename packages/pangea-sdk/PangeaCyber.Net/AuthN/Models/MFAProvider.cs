using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MFAProvider
    {
        ///
        [EnumMember(Value = "totp")]
        TOTP,
        
        ///
        [EnumMember(Value = "email_otp")]
        EmailOTP,
        
        ///
        [EnumMember(Value = "sms_otp")]
        SmsOTP
    }
}

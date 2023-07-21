using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MFAProvider
    {
        ///
        [JsonProperty("totp")]
        TOTP,
        
        ///
        [JsonProperty("email_otp")]
        EmailOTP,
        
        ///
        [JsonProperty("sms_otp")]
        SmsOTP
    }
}

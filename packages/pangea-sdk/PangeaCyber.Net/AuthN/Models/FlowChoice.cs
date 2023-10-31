using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum FlowChoice
    {
        ///
        [EnumMember(Value = "agreements")]
        AGREEMENTS,

        ///
        [EnumMember(Value = "captcha")]
        CAPTCHA,

        ///
        [EnumMember(Value = "email_otp")]
        EMAIL_OTP,

        ///
        [EnumMember(Value = "magiclink")]
        MAGICLINK,

        ///
        [EnumMember(Value = "password")]
        PASSWORD,

        ///
        [EnumMember(Value = "profile")]
        PROFILE,

        ///
        [EnumMember(Value = "provisional_enrollment")]
        PROVISIONAL_ENROLLMENT,

        ///
        [EnumMember(Value = "reset_password")]
        RESET_PASSWORD,

        ///
        [EnumMember(Value = "set_mail")]
        SET_EMAIL,

        ///
        [EnumMember(Value = "set_password")]
        SET_PASSWORD,

        ///
        [EnumMember(Value = "sms_otp")]
        SMS_OTP,

        ///
        [EnumMember(Value = "social")]
        SOCIAL,

        ///
        [EnumMember(Value = "totp")]
        TOTP,

        ///
        [EnumMember(Value = "verify_email")]
        VERIFY_EMAIL
    }

}

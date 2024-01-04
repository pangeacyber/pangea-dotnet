using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Store.Models
{
    /// <summary>
    /// Represents the types of authenticators.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthenticatorType
    {
        /// <summary>
        /// Email One-Time Password authenticator type.
        /// </summary>
        [EnumMember(Value = "email_otp")]
        EmailOtp,

        /// <summary>
        /// Password authenticator type.
        /// </summary>
        [EnumMember(Value = "password")]
        Password,

        /// <summary>
        /// SMS One-Time Password authenticator type.
        /// </summary>
        [EnumMember(Value = "sms_otp")]
        SmsOtp,

        /// <summary>
        /// Social authenticator type.
        /// </summary>
        [EnumMember(Value = "social")]
        Social
    }
}

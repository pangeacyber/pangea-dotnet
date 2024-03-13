using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    /// <summary>Vault key purposes.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KeyPurpose
    {
        /// <summary>Signing.</summary>
        [EnumMember(Value = "signing")]
        Signing,

        /// <summary>Encryption</summary>
        [EnumMember(Value = "encryption")]
        Encryption,

        /// <summary>JSON Web Token (JWT).</summary>
        [EnumMember(Value = "jwt")]
        JWT,

        /// <summary>Format-preserving encryption.</summary>
        [EnumMember(Value = "fpe")]
        FPE
    }
}

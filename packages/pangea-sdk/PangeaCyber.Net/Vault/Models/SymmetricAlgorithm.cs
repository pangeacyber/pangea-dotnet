using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    /// <summary>Symmetric signing algorithms.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SymmetricAlgorithm
    {
        ///
        [EnumMember(Value = "HS256")]
        HS256,

        ///
        [EnumMember(Value = "HS384")]
        HS384,

        ///
        [EnumMember(Value = "HS512")]
        HS512,

        ///
        [EnumMember(Value = "AES-CFB-128")]
        AES128_CFB,

        ///
        [EnumMember(Value = "AES-CFB-256")]
        AES256_CFB,

        ///
        [EnumMember(Value = "AES-CBC-128")]
        AES128_CBC,

        ///
        [EnumMember(Value = "AES-CBC-256")]
        AES256_CBC,

        ///
        [EnumMember(Value = "AES-GCM-256")]
        AES256_GCM,

        /// <summary>128-bit encryption using the FF3-1 algorithm. Beta feature.</summary>
        [EnumMember(Value = "AES-FF3-1-128-BETA")]
        AES128_FF3_1,

        /// <summary>256-bit encryption using the FF3-1 algorithm. Beta feature.</summary>
        [EnumMember(Value = "AES-FF3-1-256-BETA")]
        AES256_FF3_1,
    }
}

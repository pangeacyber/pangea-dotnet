using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    ///
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
        [EnumMember(Value = "AES-GCM-256")]
        AES256_GCM
    }
}

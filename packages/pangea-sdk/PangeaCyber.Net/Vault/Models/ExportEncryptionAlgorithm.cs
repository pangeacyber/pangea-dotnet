using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    /// <summary>Algorithm of an exported public key.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExportEncryptionAlgorithm
    {
        /// <summary>RSA 4096-bit key, OAEP padding, SHA512 digest.</summary>
        [EnumMember(Value = "RSA-OAEP-4096-SHA512")]
        RSA4096_OAEP_SHA512,

        /// <summary>
        /// RSA 4096-bit key, no padding.
        /// </summary>
        [EnumMember(Value = "RSA-NO-PADDING-4096-KEM")]
        RSA4096_NO_PADDING_KEM,
    }
}

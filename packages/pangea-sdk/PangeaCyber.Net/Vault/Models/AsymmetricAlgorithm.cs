using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AsymmetricAlgorithm
    {
        ///
        [EnumMember(Value = "ED25519")]
        ED25519,

        ///
        [EnumMember(Value = "ES256")]
        ES256,

        ///
        [EnumMember(Value = "ES384")]
        ES384,

        ///
        [EnumMember(Value = "ES512")]
        ES512,

        ///
        [EnumMember(Value = "RSA-PKCS1V15-2048-SHA256")]
        RSA2048_PKCS1V15_SHA256,

        ///
        [EnumMember(Value = "RSA-OAEP-2048-SHA256")]
        RSA2048_OAEP_SHA256,

        ///
        [EnumMember(Value = "ES256K")]
        ES256K,

        ///
        [EnumMember(Value = "RSA-OAEP-2048-SHA1")]
        RSA2048_OAEP_SHA1,

        ///
        [EnumMember(Value = "RSA-OAEP-2048-SHA512")]
        RSA2048_OAEP_SHA512,

        ///
        [EnumMember(Value = "RSA-OAEP-3072-SHA1")]
        RSA3072_OAEP_SHA1,

        ///
        [EnumMember(Value = "RSA-OAEP-3072-SHA256")]
        RSA3072_OAEP_SHA256,

        ///
        [EnumMember(Value = "RSA-OAEP-3072-SHA512")]
        RSA3072_OAEP_SHA512,

        ///
        [EnumMember(Value = "RSA-OAEP-4096-SHA1")]
        RSA4096_OAEP_SHA1,

        ///
        [EnumMember(Value = "RSA-OAEP-4096-SHA256")]
        RSA4096_OAEP_SHA256,

        ///
        [EnumMember(Value = "RSA-OAEP-4096-SHA512")]
        RSA4096_OAEP_SHA512,

        ///
        [EnumMember(Value = "RSA-PSS-2048-SHA256")]
        RSA2048_PSS_SHA256,

        ///
        [EnumMember(Value = "RSA-PSS-3072-SHA256")]
        RSA3072_PSS_SHA256,

        ///
        [EnumMember(Value = "RSA-PSS-4096-SHA256")]
        RSA4096_PSS_SHA256,

        ///
        [EnumMember(Value = "RSA-PSS-4096-SHA512")]
        RSA4096_PSS_SHA512,

    }
}

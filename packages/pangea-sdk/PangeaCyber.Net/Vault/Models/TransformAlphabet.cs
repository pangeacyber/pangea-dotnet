using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault.Models
{
    /// <summary>Character sets for format-preserving encryption.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransformAlphabet
    {
        /// <summary>Lowercase alphabet (a-z).</summary>
        [EnumMember(Value = "alphalower")]
        ALPHA_LOWER,

        /// <summary>Uppercase alphabet (A-Z).</summary>
        [EnumMember(Value = "alphaupper")]
        ALPHA_UPPER,

        /// <summary>Alphanumeric (a-z, A-Z, 0-9).</summary>
        [EnumMember(Value = "alphanumeric")]
        ALPHANUMERIC,

        /// <summary>Lowercase alphabet with numbers (a-z, 0-9).</summary>
        [EnumMember(Value = "alphanumericlower")]
        ALPHANUMERIC_LOWER,

        /// <summary>Uppercase alphabet with numbers (A-Z, 0-9).</summary>
        [EnumMember(Value = "alphanumericupper")]
        ALPHANUMERIC_UPPER,

        /// <summary>Numeric (0-9).</summary>
        [EnumMember(Value = "numeric")]
        NUMERIC
    }
}

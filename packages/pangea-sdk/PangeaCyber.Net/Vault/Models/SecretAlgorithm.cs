using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Vault
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecretAlgorithm
    {
        ///
        [EnumMember(Value = "base32")]
        Base32
    }
}

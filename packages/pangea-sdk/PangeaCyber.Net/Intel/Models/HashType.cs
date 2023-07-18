using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Intel
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HashType
    {
        ///
        [EnumMember(Value = "sha256")]
        SHA256,

        ///
        [EnumMember(Value = "sha1")]
        SHA1,

        ///
        [EnumMember(Value = "md5")]
        MD5
    }
}

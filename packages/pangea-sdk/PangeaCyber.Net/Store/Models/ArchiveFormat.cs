using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Store.Models
{
    ///
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ArchiveFormat
    {
        ///
        [EnumMember(Value = "tar")]
        Tar,

        ///
        [EnumMember(Value = "zip")]
        Zip
    }
}

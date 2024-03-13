using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PangeaCyber.Net.Audit.Models
{
    ///
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DownloadFormat
    {
        ///
        [EnumMember(Value = "json")]
        JSON,

        ///
        [EnumMember(Value = "csv")]
        CSV,

    }
}

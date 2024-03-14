using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit.Models
{
    /// <summary>Download format.</summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DownloadFormat
    {
        /// <summary>JSON.</summary>
        [EnumMember(Value = "json")]
        JSON,

        /// <summary>CSV.</summary>
        [EnumMember(Value = "csv")]
        CSV,
    }
}

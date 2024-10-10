using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents the types of links.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LinkType
    {
        /// <summary>
        /// Upload link type.
        /// </summary>
        [EnumMember(Value = "upload")]
        Upload,

        /// <summary>
        /// Download link type.
        /// </summary>
        [EnumMember(Value = "download")]
        Download,

        /// <summary>
        /// Editor link type.
        /// </summary>
        [EnumMember(Value = "editor")]
        Editor
    }
}

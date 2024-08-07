
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Models
{
    /// <kind>class</kind>
    /// <summary>
    /// DebugPath
    /// </summary>
    public class DebugPath
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("action")]
        public string? Action { get; set; }
    }
}

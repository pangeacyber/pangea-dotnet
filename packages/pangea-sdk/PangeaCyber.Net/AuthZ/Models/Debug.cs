
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Models
{
    /// <kind>class</kind>
    /// <summary>
    /// Debug
    /// </summary>
    public class Debug
    {
        ///
        [JsonProperty("path")]
        public DebugPath[] Path { get; set; } = { };

    }
}

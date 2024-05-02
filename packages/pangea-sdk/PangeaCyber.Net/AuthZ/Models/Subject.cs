
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Models
{
    /// <kind>class</kind>
    /// <summary>
    /// Subject
    /// </summary>
    public class Subject
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; set; }

        ///
        [JsonProperty("action")]
        public string? Action { get; set; }

        ///
        public Subject(string type)
        {
            Type = type;
        }
    }
}

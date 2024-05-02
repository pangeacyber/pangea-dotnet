
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Models
{
    /// <kind>class</kind>
    /// <summary>
    /// Resource
    /// </summary>
    public class Resource
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; set; }

        ///
        public Resource(string type)
        {
            Type = type;
        }
    }
}

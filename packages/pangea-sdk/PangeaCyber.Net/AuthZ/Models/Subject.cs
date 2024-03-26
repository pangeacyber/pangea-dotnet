
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
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; set; } = default!;

        ///
        [JsonProperty("action")]
        public string? Action { get; set; } = default!;


        ///
        public Subject(string _namespace)
        {
            Namespace = _namespace;
        }

    }
}

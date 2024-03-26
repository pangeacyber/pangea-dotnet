
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
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; set; } = default!;

        ///
        public Resource(string _namespace)
        {
            Namespace = _namespace;
        }

    }
}

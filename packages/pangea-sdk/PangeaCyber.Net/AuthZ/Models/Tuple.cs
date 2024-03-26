
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Models
{
    /// <kind>class</kind>
    /// <summary>
    /// Tuple
    /// </summary>
    public class Tuple
    {
        ///
        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        ///
        [JsonProperty("relation")]
        public string Relation { get; set; }

        ///
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

        ///
        public Tuple(Resource resource, string relation, Subject subject)
        {
            Resource = resource;
            Relation = relation;
            Subject = subject;
        }
    }
}

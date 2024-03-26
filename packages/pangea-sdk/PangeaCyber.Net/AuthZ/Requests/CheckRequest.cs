
using Newtonsoft.Json;
using PangeaCyber.Net.AuthZ.Models;

namespace PangeaCyber.Net.AuthZ.Requests
{
    /// <kind>class</kind>
    /// <summary>
    /// CheckRequest
    /// </summary>
    public class CheckRequest : BaseRequest
    {
        ///
        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        ///
        [JsonProperty("action")]
        public string Action { get; set; }

        ///
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

        ///
        [JsonProperty("debug")]
        public bool? Debug { get; set; }

        ///
        [JsonProperty("attributes")]
        public Dictionary<string, object>? Attributes { get; set; }

        ///
        public CheckRequest(Resource resource, string action, Subject subject)
        {
            Resource = resource;
            Action = action;
            Subject = subject;
        }
    }
}


using Newtonsoft.Json;
using PangeaCyber.Net.AuthZ.Models;

namespace PangeaCyber.Net.AuthZ.Requests
{
    /// <kind>class</kind>
    /// <summary>
    /// ListResourcesRequest
    /// </summary>
    public class ListResourcesRequest : BaseRequest
    {
        ///
        [JsonProperty("type")]
        public string Type { get; set; }

        ///
        [JsonProperty("action")]
        public string Action { get; set; }

        ///
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

        ///
        [JsonProperty("attributes")]
        public Dictionary<string, object>? Attributes { get; set; }

        ///
        public ListResourcesRequest(string type, string action, Subject subject)
        {
            Type = type;
            Action = action;
            Subject = subject;
        }
    }
}

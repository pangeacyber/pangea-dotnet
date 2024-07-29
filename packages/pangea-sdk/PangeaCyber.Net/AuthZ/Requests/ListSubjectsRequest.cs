
using Newtonsoft.Json;
using PangeaCyber.Net.AuthZ.Models;

namespace PangeaCyber.Net.AuthZ.Requests
{
    /// <kind>class</kind>
    /// <summary>
    /// ListSubjectsRequest
    /// </summary>
    public class ListSubjectsRequest : BaseRequest
    {
        ///
        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        ///
        [JsonProperty("action")]
        public string Action { get; set; }

        ///
        [JsonProperty("attributes")]
        public Dictionary<string, object>? Attributes { get; set; }

        ///
        public ListSubjectsRequest(Resource resource, string action)
        {
            Resource = resource;
            Action = action;
        }
    }
}

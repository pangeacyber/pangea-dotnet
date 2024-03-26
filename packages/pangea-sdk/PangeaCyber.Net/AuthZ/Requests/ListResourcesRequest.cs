
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
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        ///
        [JsonProperty("action")]
        public string Action { get; set; }

        ///
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

        ///
        public ListResourcesRequest(string _namespace, string action, Subject subject)
        {
            Namespace = _namespace;
            Action = action;
            Subject = subject;
        }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    /// <summary>Breached request parameters.</summary>
    public class BreachRequest : BaseRequest
    {
        /// <summary>The ID of a breach returned by a provider.</summary>
        [JsonProperty("breach_id")]
        public string? BreachID { get; set; }

        /// <summary>Get breach data from this provider.</summary>
        [JsonProperty("provider")]
        public string? Provider { get; set; }

        /// <summary>Echo the API parameters in the response.</summary>
        [JsonProperty("verbose")]
        public bool? Verbose { get; set; }

        /// <summary>A token given in the raw response from SpyCloud. Post this back to paginate results.</summary>
        [JsonProperty("cursor")]
        public string? Cursor { get; set; }

        /// <summary>This parameter allows you to define the starting point for a date range query on the spycloud_publish_date field.</summary>
        [JsonProperty("start")]
        public string? Start { get; set; }

        /// <summary>This parameter allows you to define the ending point for a date range query on the spycloud_publish_date field.</summary>
        [JsonProperty("end")]
        public string? End { get; set; }

        /// <summary>Filter for records that match one of the given severities.</summary>
        [JsonProperty("severity")]
        public string[]? Severity { get; set; }

        /// <summary>Constructor.</summary>
        public BreachRequest(string breachID)
        {
            BreachID = breachID;
        }
    }
}

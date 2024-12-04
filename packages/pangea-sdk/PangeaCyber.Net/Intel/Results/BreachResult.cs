using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    /// <summary>Breach result fields.</summary>
    public class BreachResult
    {
        /// <summary>A flag indicating if the lookup was successful</summary>
        [JsonProperty("found")]
        public bool Found { get; private set; }

        /// <summary>Breach details given by the provider</summary>
        [JsonProperty("raw_data")]
        public Dictionary<string, object>? Data { get; private set; }

        /// <summary>The parameters, which were passed in the request, echoed back.</summary>
        [JsonProperty("parameters")]
        public Dictionary<string, object>? Parameters { get; private set; }

    }
}

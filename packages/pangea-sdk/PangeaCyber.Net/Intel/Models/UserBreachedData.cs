using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class UserBreachedData
    {
        ///
        [JsonProperty("found_in_breach")]
        public bool FoundInBreach { get; set; }

        ///
        [JsonProperty("breach_count")]
        public int BreachCount { get; set; }
    }
}

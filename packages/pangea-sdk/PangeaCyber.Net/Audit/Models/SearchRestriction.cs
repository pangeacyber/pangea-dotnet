using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// SearchRestriction
    /// </summary>
    public class SearchRestriction
    {
        ///
        [JsonProperty("actor")]
        public string[] Actor { get; set; } = default!;

        ///
        [JsonProperty("source")]
        public string[] source { get; set; } = default!;

        ///
        [JsonProperty("target")]
        public string[] target { get; set; } = default!;

        ///
        [JsonProperty("status")]
        public string[] status { get; set; } = default!;

        ///
        [JsonProperty("action")]
        public string[] action { get; set; } = default!;
    }
}

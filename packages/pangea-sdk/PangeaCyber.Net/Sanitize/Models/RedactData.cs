using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class RedactData
    {
        ///
        [JsonProperty("redaction_count")]
        public int? RedactionCount { get; set; }

        ///
        [JsonProperty("summary_counts")]
        public Dictionary<string, object>? SummaryCounts { get; set; }

        ///
        public RedactData() { }
    }
}

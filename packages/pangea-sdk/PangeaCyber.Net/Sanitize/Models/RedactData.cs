using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Redact data.</summary>
    public class RedactData
    {
        /// <summary>Number of items redacted.</summary>
        [JsonProperty("redaction_count")]
        public int? RedactionCount { get; set; }

        /// <summary>Summary counts.</summary>
        [JsonProperty("summary_counts")]
        public Dictionary<string, object>? SummaryCounts { get; set; }

        /// <summary>Constructor.</summary>
        public RedactData() { }
    }
}

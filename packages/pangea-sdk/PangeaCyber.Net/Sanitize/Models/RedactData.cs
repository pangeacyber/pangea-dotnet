using Newtonsoft.Json;
using PangeaCyber.Net.Sanitize.Models;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Redact data.</summary>
    public class RedactData
    {
        /// <summary>Number of items redacted.</summary>
        [JsonProperty("redaction_count")]
        public int RedactionCount { get; private set; } = default!;

        /// <summary>Summary counts.</summary>
        [JsonProperty("summary_counts")]
        public Dictionary<string, int> SummaryCounts { get; private set; } = default!;

        /// <summary>The scoring result of a set of rules.</summary>
        [JsonProperty("recognizer_results")]
        public List<RedactRecognizerResult> RecognizerResults { get; private set; } = default!;

        /// <summary>Constructor.</summary>
        public RedactData() { }
    }
}

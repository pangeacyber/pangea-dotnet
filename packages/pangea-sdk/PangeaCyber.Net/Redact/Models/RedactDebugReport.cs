
using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <summary>Describes the decision process for redactions</summary>
    public sealed class RedactDebugReport
    {
        ///
        [JsonProperty("summary_counts")]
        public Dictionary<string, int> SummaryCounts { get; private set; } = default!;

        /// <summary>The scoring result of a rule</summary>
        [JsonProperty("recognizer_results")]
        public RedactRecognizerResult[] RecognizerResults { get; private set; } = default!;
    }
}

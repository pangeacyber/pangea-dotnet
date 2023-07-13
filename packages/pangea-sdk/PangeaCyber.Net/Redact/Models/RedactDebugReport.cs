
using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactDebugReport
    /// </summary>
    public sealed class RedactDebugReport
    {
        ///
        [JsonProperty("summary_counts")]
        public Dictionary<string, int> SummaryCounts { get; private set; } = default!;

		///
        [JsonProperty("recognizer_results")]
        public RedactRecognizerResult[] RecognizerResults { get; private set; } = default!;
    }
}

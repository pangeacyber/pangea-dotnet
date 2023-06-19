using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactStructuredResult
    /// </summary>
    public sealed class RedactStructuredResult
    {
        ///
        [JsonProperty("count")]
        public int Count { get; private set; } = default!;

		///
        [JsonProperty("report")]
        public RedactDebugReport Report { get; private set; } = default!;

        ///
        [JsonProperty("redacted_data")]
        public Object RedactedData { get; private set; } = default!;

    }
}

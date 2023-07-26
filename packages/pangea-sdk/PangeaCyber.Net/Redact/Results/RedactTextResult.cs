using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactTextResult
    /// </summary>
    public sealed class RedactTextResult
    {
        ///
        [JsonProperty("count")]
        public int Count { get; private set; } = default!;

        ///
        [JsonProperty("report")]
        public RedactDebugReport Report { get; private set; } = default!;

        ///
        [JsonProperty("redacted_text")]
        public string RedactedText { get; private set; } = default!;

    }
}

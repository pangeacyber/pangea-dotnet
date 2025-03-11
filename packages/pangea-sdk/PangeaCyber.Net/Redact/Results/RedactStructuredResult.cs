using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactStructuredResult
    /// </summary>
    public sealed class RedactStructuredResult
    {
        /// <summary>Number of redactions present in the data</summary>
        [JsonProperty("count")]
        public int Count { get; private set; } = default!;

        /// <summary>Describes the decision process for redactions</summary>
        [JsonProperty("report")]
        public RedactDebugReport Report { get; private set; } = default!;

        /// <summary>The redacted data</summary>
        [JsonProperty("redacted_data")]
        public object RedactedData { get; private set; } = default!;

        /// <summary>If an FPE redaction method returned results, this will be the context passed to unredact.</summary>
        [JsonProperty("fpe_context")]
        public string? FPEContext { get; private set; }
    }
}

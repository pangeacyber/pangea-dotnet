using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactTextResult
    /// </summary>
    public sealed class RedactTextResult
    {
        /// <summary>Number of redactions present in the text</summary>
        [JsonProperty("count")]
        public int Count { get; private set; } = default!;

        /// <summary>Describes the decision process for redactions</summary>
        [JsonProperty("report")]
        public RedactDebugReport Report { get; private set; } = default!;

        /// <summary>The redacted text</summary>
        [JsonProperty("redacted_text")]
        public string RedactedText { get; private set; } = default!;

        /// <summary>If an FPE redaction method returned results, this will be the context passed to unredact.</summary>
        [JsonProperty("fpe_context")]
        public string? FPEContext { get; private set; }
    }
}

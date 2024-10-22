using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize.Models
{
    /// <summary>Redact recognizer result.</summary>
    public sealed class RedactRecognizerResult
    {
        /// <summary>The entity name.</summary>
        [JsonProperty("field_type")]
        public string FieldType { get; set; } = default!;

        /// <summary>The certainty score that the entity matches this specific snippet.</summary>
        [JsonProperty("score")]
        public float Score { get; set; } = default!;

        /// <summary>The text snippet that matched.</summary>
        [JsonProperty("text")]
        public string Text { get; set; } = default!;

        /// <summary>The starting index of a snippet.</summary>
        [JsonProperty("start")]
        public int Start { get; set; } = default!;

        /// <summary>The ending index of a snippet.</summary>
        [JsonProperty("end")]
        public int End { get; set; } = default!;

        /// <summary>Indicates if this rule was used to anonymize a text snippet.</summary>
        [JsonProperty("redacted")]
        public bool Redacted { get; set; } = default!;

        /// <summary>Constructor</summary>
        public RedactRecognizerResult() { }
    }
}

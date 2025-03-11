using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <summary>The scoring result of a rule</summary>
    public sealed class RedactRecognizerResult
    {
        /// <summary>The entity name</summary>
        [JsonProperty("field_type")]
        public string FieldType { get; private set; } = default!;

        /// <summary>The certainty score that the entity matches this specific snippet</summary>
        [JsonProperty("score")]
        public double Score { get; private set; } = default!;

        /// <summary>The text snippet that matched</summary>
        [JsonProperty("text")]
        public string Text { get; private set; } = default!;

        /// <summary>The starting index of a snippet</summary>
        [JsonProperty("start")]
        public int Start { get; private set; } = default!;

        /// <summary>The ending index of a snippet</summary>
        [JsonProperty("end")]
        public int End { get; private set; } = default!;

        /// <summary>Indicates if this rule was used to anonymize a text snippet</summary>
        [JsonProperty("redacted")]
        public bool Redacted { get; private set; } = default!;

        /// <summary>
        /// If this result relates to a specific structured text field, the key pointing to this text will be
        /// provided
        /// </summary>
        [JsonProperty("data_key")]
        public string DateKey { get; private set; } = default!;
    }
}

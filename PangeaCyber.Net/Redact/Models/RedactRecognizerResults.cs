

using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactRecognizerResult
    /// </summary>
    public sealed class RedactRecognizerResult
    {
        ///
        [JsonProperty("field_type")]
        public string FieldType { get; private set; } = default!;

        ///
        [JsonProperty("score")]
        public double Score { get; private set; } = default!;

        ///
        [JsonProperty("text")]
        public string Text { get; private set; } = default!;

        ///
        [JsonProperty("start")]
        public int Start { get; private set; } = default!;

        ///
        [JsonProperty("end")]
        public int End { get; private set; } = default!;

        ///
        [JsonProperty("redacted")]
        public bool Redacted { get; private set; } = default!;

        ///
        [JsonProperty("data_key")]
        public string DateKey { get; private set; } = default!;
    }
}

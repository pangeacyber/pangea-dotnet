using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    ///
    public class RedactionMethodOverrides
    {

        ///
        [JsonProperty("masking_type")]
        public RedactType RedactionType { get; set; } = default!;

        ///
        [JsonProperty("hash")]
        public Dictionary<string, object>? Hash { get; set; } = default!;

        ///
        [JsonProperty("fpe_alphabet")]
        public FPEAlphabet? FpeAlphabet { get; set; } = default!;

        ///
        [JsonProperty("partial_masking")]
        public PartialMasking? PartialMasking { get; set; } = default!;

        ///
        [JsonProperty("redaction_value")]
        public string? RedactionValue { get; set; } = default!;
    }
}

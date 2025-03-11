using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <summary>This field allows users to specify the redaction method per rule and its various parameters.</summary>
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

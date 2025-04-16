using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    ///
    public class PartialMasking
    {
        ///
        [JsonProperty("masking_type")]
        public MaskingType? MaskingType { get; set; } = default!;

        ///
        [JsonProperty("unmasked_from_left")]
        public int? UnmaskedFromLeft { get; set; } = default!;

        ///
        [JsonProperty("unmasked_from_right")]
        public int? UnmaskedFromRight { get; set; } = default!;

        ///
        [JsonProperty("masked_from_left")]
        public int? MaskedFromLeft { get; set; } = default!;

        ///
        [JsonProperty("masked_from_right")]
        public int? MaskedFromRight { get; set; } = default!;

        ///
        [JsonProperty("chars_to_ignore")]
        public List<char>? CharsToIgnore { get; set; } = default!;

        ///
        [JsonProperty("masking_char")]
        public char? MaskingChar { get; set; } = default!;

        ///
        private PartialMasking() { }
    }
}

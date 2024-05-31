namespace PangeaCyber.Net.Redact
{
    ///
    public class PartialMasking
    {
        ///
        public MaskingType? MaskingType { get; set; } = default!;
        ///
        public int? UnmaskedFromLeft { get; set; } = default!;
        ///
        public int? UnmaskedFromRight { get; set; } = default!;
        ///
        public int? MaskedFromLeft { get; set; } = default!;
        ///
        public int? MaskedFromRight { get; set; } = default!;
        ///
        public List<string>? CharsToIgnore { get; set; } = default!;
        ///
        public List<string>? MaskingChar { get; set; } = default!;

        ///
        private PartialMasking() { }
    }
}

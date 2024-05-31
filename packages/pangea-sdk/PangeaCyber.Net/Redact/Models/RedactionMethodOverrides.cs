namespace PangeaCyber.Net.Redact
{
    ///
    public class RedactionMethodOverrides
    {
        ///
        public RedactType RedactionType { get; set; } = default!;

        ///
        public Dictionary<string, object>? Hash { get; set; } = default!;

        ///
        public FPEAlphabet? FpeAlphabet { get; set; } = default!;

        ///
        public PartialMasking? PartialMasking { get; set; } = default!;

        ///
        public string? RedactionValue { get; set; } = default!;
    }
}

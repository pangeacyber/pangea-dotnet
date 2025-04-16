using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact;

public sealed class Redaction
{
    [JsonProperty("masking_type")]
    public RedactType RedactionType { get; set; } = default!;

    [JsonProperty("hash")]
    public Dictionary<string, object>? Hash { get; set; }

    [JsonProperty("fpe_alphabet")]
    public FPEAlphabet? FpeAlphabet { get; set; } = default!;

    [JsonProperty("partial_masking")]
    public PartialMasking? PartialMasking { get; set; }

    [JsonProperty("redaction_value")]
    public string? RedactionValue { get; set; } = default!;
}

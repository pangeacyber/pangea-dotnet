using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class SanitizeData
    {
        ///
        [JsonProperty("defang")]
        public DefangData? Defang { get; set; }

        ///
        [JsonProperty("redact")]
        public RedactData? Redact { get; set; }

        ///
        [JsonProperty("malicious_file")]
        public bool? MaliciousFile { get; set; }

        ///
        [JsonProperty("cdr")]
        public CDR? CDR { get; set; }

        ///
        public SanitizeData() { }
    }
}

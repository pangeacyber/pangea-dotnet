using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Sanitize data.</summary>
    public class SanitizeData
    {
        /// <summary>Defang data.</summary>
        [JsonProperty("defang")]
        public DefangData? Defang { get; set; }

        /// <summary>Redact data.</summary>
        [JsonProperty("redact")]
        public RedactData? Redact { get; set; }

        /// <summary>If the file scanned was malicious.</summary>
        [JsonProperty("malicious_file")]
        public bool? MaliciousFile { get; set; }

        /// <summary>Constructor.</summary>
        public SanitizeData() { }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Content.</summary>
    public class Content
    {
        /// <summary>Perform URL Intel lookup.</summary>
        [JsonProperty("url_intel")]
        public bool? URLIntel { get; set; }

        /// <summary>Provider to use for URL Intel.</summary>
        [JsonProperty("url_intel_provider")]
        public string? URLIntelProvider { get; set; }

        /// <summary>Perform Domain Intel lookup.</summary>
        [JsonProperty("domain_intel")]
        public bool? DomainIntel { get; set; }

        /// <summary>Provider to use for Domain Intel lookup.</summary>
        [JsonProperty("domain_intel_provider")]
        public string? DomainIntelProvider { get; set; }

        /// <summary>Defang external links.</summary>
        [JsonProperty("defang")]
        public bool? Defang { get; set; }

        /// <summary>Defang risk threshold.</summary>
        [JsonProperty("defang_threshold")]
        public int? DefangThreshold { get; set; }

        /// <summary>Redact sensitive content.</summary>
        [JsonProperty("redact")]
        public bool? Redact { get; set; }

        /// <summary>
        /// If redact is enabled, avoids redacting the file and instead returns
        /// the PII analysis engine results.Only works if redact is enabled.
        /// </summary>
        [JsonProperty("redact_detect_only")]
        public bool? RedactDetectOnly { get; set; }

        /// <summary>Remove file attachments (PDF only).</summary>
        [JsonProperty("remove_attachments")]
        public bool? RemoveAttachments { get; set; }

        /// <summary>Remove interactive content (PDF only).</summary>
        [JsonProperty("remove_interactive")]
        public bool? RemoveInteractive { get; set; }

        /// <summary>Constructor.</summary>
        public Content() { }
    }
}

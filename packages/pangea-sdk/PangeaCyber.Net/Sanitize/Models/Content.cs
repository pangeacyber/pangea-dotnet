using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class Content
    {
        ///
        [JsonProperty("url_intel")]
        public bool? URLIntel { get; set; }

        ///
        [JsonProperty("url_intel_provider")]
        public string? URLIntelProvider { get; set; }

        ///
        [JsonProperty("domain_intel")]
        public bool? DomainIntel { get; set; }

        ///
        [JsonProperty("domain_intel_provider")]
        public string? DomainIntelProvider { get; set; }

        ///
        [JsonProperty("defang")]
        public bool? Defang { get; set; }

        ///
        [JsonProperty("defang_threshold")]
        public int? DefangThreshold { get; set; }

        ///
        [JsonProperty("redact")]
        public bool? Redact { get; set; }

        ///
        [JsonProperty("remove_attachments")]
        public bool? RemoveAttachments { get; set; }

        ///
        [JsonProperty("remove_interactive")]
        public bool? RemoveInteractive { get; set; }

        ///
        public Content() { }
    }
}

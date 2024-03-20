using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Defang data.</summary>
    public class DefangData
    {
        /// <summary>Number of external links found.</summary>
        [JsonProperty("external_urls_count")]
        public int? ExternalURLsCount { get; set; }

        /// <summary>Number of external domains found.</summary>
        [JsonProperty("external_domains_count")]
        public int? ExternalDomainsCount { get; set; }

        /// <summary>Number of items defanged per provided rules and detections.</summary>
        [JsonProperty("defanged_count")]
        public int? DefangedCount { get; set; }

        /// <summary>Processed N URLs: X are malicious, Y are suspicious, Z are unknown.</summary>
        [JsonProperty("url_intel_summary")]
        public string? URLIntelSummary { get; set; }

        /// <summary>Processed N Domains: X are malicious, Y are suspicious, Z are unknown.</summary>
        [JsonProperty("domain_intel_summary")]
        public string? DomainIntelSummary { get; set; }

        /// <summary>Constructor.</summary>
        public DefangData() { }
    }
}

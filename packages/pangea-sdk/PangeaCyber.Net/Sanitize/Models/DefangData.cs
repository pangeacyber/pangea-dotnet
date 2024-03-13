using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class DefangData
    {
        ///
        [JsonProperty("external_urls_count")]
        public int? ExternalURLsCount { get; set; }

        ///
        [JsonProperty("external_domains_count")]
        public int? ExternalDomainsCount { get; set; }

        ///
        [JsonProperty("defanged_count")]
        public int? DefangedCount { get; set; }

        ///
        [JsonProperty("url_intel_summary")]
        public string? URLIntelSummary { get; set; }

        ///
        [JsonProperty("domain_intel_summary")]
        public string? DomainIntelSummary { get; set; }

        ///
        public DefangData() { }
    }
}

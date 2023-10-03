using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainWhoIsData
    {
        /// <summary>
        /// Represents information about a domain.
        /// </summary>

        ///
        [JsonProperty("domain_name")]
        public string DomainName { get; private set; } = default!;

        ///
        [JsonProperty("domain_availability")]
        public string DomainAvailability { get; private set; } = default!;

        ///
        [JsonProperty("created_date")]
        public string? CreatedDate { get; private set; }

        ///
        [JsonProperty("updated_date")]
        public string? UpdatedDate { get; private set; }

        ///
        [JsonProperty("expires_date")]
        public string? ExpiresDate { get; private set; }

        ///
        [JsonProperty("host_names")]
        public List<string>? HostNames { get; private set; }

        ///
        [JsonProperty("ips")]
        public List<string>? IPs { get; private set; }

        ///
        [JsonProperty("registrar_name")]
        public string? RegistrarName { get; private set; }

        ///
        [JsonProperty("contact_email")]
        public string? ContactEmail { get; private set; }

        ///
        [JsonProperty("estimated_domain_age")]
        public int? EstimatedDomainAge { get; private set; }

        ///
        [JsonProperty("registrant_organization")]
        public string? RegistrantOrganization { get; private set; }

        ///
        [JsonProperty("registrant_country")]
        public string? RegistrantCountry { get; private set; }

        ///
        public DomainWhoIsData() { }

    }
}

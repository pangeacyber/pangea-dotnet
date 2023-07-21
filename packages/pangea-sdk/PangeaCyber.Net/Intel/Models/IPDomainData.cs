using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPDomainData
    {
        ///
        [JsonProperty("domain_found")]
        public bool DomainFound { get; set; }

        ///
        [JsonProperty("domain")]
        public string Domain { get; set; } = default!;

    }
}

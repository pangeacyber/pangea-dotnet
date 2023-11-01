using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Intelligence
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("embargo")]
        public bool Embargo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("ip_intel")]
        public IPIntelligence? IPIntel { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("domain_intel")]
        public DomainIntelligence? DomainIntel { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_intel")]
        public bool UserIntel { get; private set; }
    }
}

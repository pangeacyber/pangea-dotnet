using Newtonsoft.Json;
using PangeaCyber.Net.Intel;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class DomainIntelligence
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("is_bad")]
        public bool IsBad { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("reputation")]
        public DomainReputationData? Reputation { get; private set; }
    }
}

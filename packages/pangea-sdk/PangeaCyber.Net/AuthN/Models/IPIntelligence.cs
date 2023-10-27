using Newtonsoft.Json;
using PangeaCyber.Net.Intel;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class IPIntelligence
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("is_bad")]
        public bool IsBad { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("is_vpn")]
        public bool IsVPN { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("is_proxy")]
        public bool IsProxy { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("reputation")]
        public IPReputationData? Reputation { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("geolocation")]
        public IPGeolocateData? Geolocation { get; private set; }
    }
}

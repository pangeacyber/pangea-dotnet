using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPVPNData
    {
        ///
        [JsonProperty("is_vpn")]
        public bool IsVPN { get; set; }
    }
}

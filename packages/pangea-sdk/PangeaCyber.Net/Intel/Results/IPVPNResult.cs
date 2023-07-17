using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPVPNResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPVPNData Data { get; set; } = new IPVPNData();

    }
}

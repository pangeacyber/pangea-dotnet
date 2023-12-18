using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPVPNBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPVPNBulkData Data { get; private set; } = new IPVPNBulkData();


    }
}

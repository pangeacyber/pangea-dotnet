using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPReputationBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPReputationBulkData Data { get; private set; } = new IPReputationBulkData();


    }
}

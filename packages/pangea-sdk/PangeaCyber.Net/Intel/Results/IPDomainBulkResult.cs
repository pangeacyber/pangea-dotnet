using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPDomainBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPDomainBulkData Data { get; private set; } = new IPDomainBulkData();


    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public DomainReputationBulkData Data { get; private set; } = new DomainReputationBulkData();

    }
}

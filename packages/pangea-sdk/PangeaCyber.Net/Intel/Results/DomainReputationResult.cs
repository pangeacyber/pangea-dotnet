using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public DomainReputationData Data { get; private set; } = new DomainReputationData();

        ///
        [JsonProperty("data_details")]
        public Dictionary<string, DomainReputationDataItem>? DataDetails { get; private set; } = null;

    }
}

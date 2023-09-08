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
        [JsonProperty("data_list")]
        public Dictionary<string, DomainReputationDataItem>? DataList { get; private set; } = null;

    }
}

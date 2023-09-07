using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public DomainReputationData Data { get; set; } = new DomainReputationData();

        ///
        [JsonProperty("data_list")]
        public DomainReputationDataItem[]? DataList { get; set; } = null;

    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public DomainReputationData Data { get; private set; } = new DomainReputationData();

    }
}

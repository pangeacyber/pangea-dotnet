using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPReputationData Data { get; private set; } = new IPReputationData();


    }
}

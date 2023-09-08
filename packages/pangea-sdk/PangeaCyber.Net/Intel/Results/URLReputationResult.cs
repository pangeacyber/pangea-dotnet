using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public sealed class URLReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public URLReputationData Data { get; private set; } = new URLReputationData();

        ///
        [JsonProperty("data_details")]
        public Dictionary<string, URLReputationDataItem>? DataDetails { get; private set; } = null;

    }
}

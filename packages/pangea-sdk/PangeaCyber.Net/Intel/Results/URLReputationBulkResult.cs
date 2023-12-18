using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public sealed class URLReputationBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public URLReputationBulkData Data { get; private set; } = new URLReputationBulkData();

    }
}

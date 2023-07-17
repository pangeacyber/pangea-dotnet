using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public sealed class URLReputationResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public URLReputationData Data { get; set; }

        ///
        public URLReputationResult(){
            Data = new URLReputationData();
        }

    }
}

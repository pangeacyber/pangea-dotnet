using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainWhoIsResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public DomainWhoIsData Data { get; set; } = new DomainWhoIsData();
    }
}

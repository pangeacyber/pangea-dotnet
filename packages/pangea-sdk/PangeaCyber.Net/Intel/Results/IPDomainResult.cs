using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPDomainResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPDomainData Data { get; private set; } = new IPDomainData();

    }
}

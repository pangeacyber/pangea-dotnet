using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPProxyResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPProxyData Data { get; private set; } = new IPProxyData();

    }
}

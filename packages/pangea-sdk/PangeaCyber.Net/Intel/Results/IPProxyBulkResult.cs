using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPProxyBulkResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public IPProxyBulkData Data { get; private set; } = new IPProxyBulkData();


    }
}

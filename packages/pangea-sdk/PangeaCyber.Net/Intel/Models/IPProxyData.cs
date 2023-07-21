using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPProxyData
    {
        ///
        [JsonProperty("is_proxy")]
        public bool IsProxy { get; set; }
    }
}

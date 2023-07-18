using Newtonsoft.Json;

namespace PangeaCyber.Net.Embargo
{
    ///
    public class IPCheckRequest : BaseRequest
    {
        ///
        [JsonProperty("ip")]
        public string IP { get; set; }

        ///
        public IPCheckRequest(string ip)
        {
            IP = ip;
        }

    }
}
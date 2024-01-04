using Newtonsoft.Json;

namespace PangeaCyber.Net.Store.Requests
{
    ///
    public class ShareLinkGetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;
    }
}

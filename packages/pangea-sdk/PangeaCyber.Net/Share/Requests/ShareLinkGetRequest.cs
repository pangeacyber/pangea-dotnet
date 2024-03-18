using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkGetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkDeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("ids")]
        public List<string> IDs { get; set; } = new List<string>();
    }
}

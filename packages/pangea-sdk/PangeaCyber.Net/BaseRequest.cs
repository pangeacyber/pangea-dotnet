using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    ///
    public class BaseRequest
    {
        ///
        [JsonProperty("config_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfigID { get; set; } = default!;

        ///
        public BaseRequest() {
        }

    }
}

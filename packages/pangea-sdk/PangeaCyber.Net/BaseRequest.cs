using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    ///
    public class BaseRequest
    {
        ///
        [JsonProperty("config_id")]
        public string ConfigID { get; set; } = default!;

        ///
        public BaseRequest()
        {
        }

    }
}

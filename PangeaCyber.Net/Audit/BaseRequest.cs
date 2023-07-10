using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{

    ///
    public class BaseRequest
    {
        ///
        [JsonProperty("config_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? ConfigID { get; set; }

        ///
        public BaseRequest() {
            ConfigID = null;
        }

        ///
        public string? GetConfigID()
        {
            return ConfigID;
        }

        ///
        public void SetConfigID(string configID)
        {
            ConfigID = configID;
        }
    }
}

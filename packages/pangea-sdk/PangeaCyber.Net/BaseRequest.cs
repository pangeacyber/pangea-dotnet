using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    ///
    public class BaseRequest
    {
        ///
        [JsonProperty("config_id")]
        public string? ConfigID { get; set; } = null;

        ///
        [JsonProperty("transfer_method")]
        public TransferMethod? TransferMethod { get; protected set; } = null;


        ///
        public BaseRequest()
        {
        }

    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net
{
    /// <summary>Properties common to multiple requests.</summary>
    public class BaseRequest
    {
        /// <summary>Config ID.</summary>
        [JsonProperty("config_id")]
        public string? ConfigID { get; set; }

        /// <summary>Transfer method used to upload file data.</summary>
        [JsonProperty("transfer_method")]
        public TransferMethod? TransferMethod { get; protected set; }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Store.Requests
{
    /// <summary>
    /// Represents a get request.
    /// </summary>
    public class GetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string? Id { get; set; }

        ///
        [JsonProperty("path")]
        public string? Path { get; set; }

        ///
        [JsonIgnore]
        public TransferMethod? RequestTransferMethod
        {
            set
            {
                TransferMethod = value;
            }
        }
    }
}

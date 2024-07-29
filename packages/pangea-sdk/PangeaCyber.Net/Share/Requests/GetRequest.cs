using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    /// <summary>
    /// Represents a get request.
    /// </summary>
    public class GetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string? ID { get; set; }

        ///
        [JsonProperty("path")]
        public string? Path { get; set; }

        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

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

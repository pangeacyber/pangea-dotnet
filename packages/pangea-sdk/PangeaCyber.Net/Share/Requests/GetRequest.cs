using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    /// <summary>
    /// Represents a get request.
    /// </summary>
    public class GetRequest : BaseRequest
    {
        /// <summary>The ID of the object to retrieve.</summary>
        [JsonProperty("id")]
        public string? ID { get; set; }

        /// <summary>The path of the object to retrieve.</summary>
        [JsonProperty("path")]
        public string? Path { get; set; }

        /// <summary>If the file was protected with a password, the password to decrypt with.</summary>
        [JsonProperty("password")]
        public string? Password { get; set; }

        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }

        /// <summary>The requested transfer method for the file data.</summary>
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

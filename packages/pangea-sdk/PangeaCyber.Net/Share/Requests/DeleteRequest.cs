using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    /// <summary>
    /// Represents a delete request.
    /// </summary>
    public class DeleteRequest : BaseRequest
    {
        /// <summary> The ID of the object to delete.</summary>
        [JsonProperty("id")]
        public string? ID { get; set; }

        /// <summary> If true, delete a folder even if it's not empty. Deletes the contents of folder as well.</summary>
        [JsonProperty("force")]
        public bool? Force { get; set; }

        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }
    }
}

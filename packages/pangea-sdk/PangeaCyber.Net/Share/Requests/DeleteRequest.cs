using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Requests
{
    /// <summary>
    /// Represents a delete request.
    /// </summary>
    public class DeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string? ID { get; set; }

        ///
        [JsonProperty("force")]
        public bool? Force { get; set; }

        ///
        [JsonProperty("path")]
        public string? Path { get; set; }
    }
}

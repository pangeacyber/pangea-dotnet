using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents a folder creation request.
    /// </summary>
    public class FolderCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("name")]
        public string? Name { get; set; }

        ///
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        ///
        [JsonProperty("path")]
        public string? Path { get; set; }

        ///
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }
    }
}

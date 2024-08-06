using Newtonsoft.Json;

namespace PangeaCyber.Net.Share.Models
{
    /// <summary>
    /// Represents a folder creation request.
    /// </summary>
    public class FolderCreateRequest : BaseRequest
    {
        /// <summary> The name of an object.</summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary> A set of string-based key/value pairs used to provide additional data about an object.</summary>
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        /// <summary> The ID of a stored object.</summary>
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        /// <summary> An case-sensitive path to an object. Contains a sequence of path segments delimited by the / character. Any path ending in a / character refers to a folder.</summary>
        [JsonProperty("path")]
        public string? Path { get; set; }

        /// <summary> A list of user-defined tags.</summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }
    }
}

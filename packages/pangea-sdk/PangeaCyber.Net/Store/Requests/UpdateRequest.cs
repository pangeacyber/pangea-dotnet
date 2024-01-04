using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Requests
{
    /// <summary>
    /// Represents an update request.
    /// </summary>
    public class UpdateRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("path")]
        public string? Path { get; set; }

        ///
        [JsonProperty("add_metadata")]
        public Metadata? AddMetadata { get; set; }

        ///
        [JsonProperty("remove_metadata")]
        public Metadata? RemoveMetadata { get; set; }

        ///
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///
        [JsonProperty("add_tags")]
        public Tags? AddTags { get; set; }

        ///
        [JsonProperty("remove_tags")]
        public Tags? RemoveTags { get; set; }

        ///
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        ///
        [JsonProperty("parent_id")]
        public string? ParentID { get; set; }

        ///
        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; }
    }
}

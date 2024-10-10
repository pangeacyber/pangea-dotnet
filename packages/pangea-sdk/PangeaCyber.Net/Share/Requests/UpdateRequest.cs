using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    /// <summary>
    /// Represents an update request.
    /// </summary>
    public class UpdateRequest : BaseRequest
    {
        ///<summary>An identifier for the file to update.</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>
        /// Set the parent (folder). Leave blank for the root folder. Path must resolve to <c>parent_id</c> if also set.
        /// </summary>
        [JsonProperty("folder")]
        public string? Folder { get; set; }

        ///<summary>A list of Metadata key/values to set in the object. If a provided key exists, the value will be replaced.</summary>
        [JsonProperty("add_metadata")]
        public Metadata? AddMetadata { get; set; }

        ///<summary>Protect the file with the supplied password.</summary>
        [JsonProperty("add_password")]
        public string? AddPassword { get; set; }

        ///<summary>The algorithm to use to password protect the file.</summary>
        [JsonProperty("add_password_algorithm")]
        public string? AddPasswordAlgorithm { get; set; }

        ///<summary>A list of Tags to add. It is not an error to provide a tag which already exists.</summary>
        [JsonProperty("add_tags")]
        public Tags? AddTags { get; set; }

        ///<summary>Sets the object's Name.</summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        ///<summary>Set the object's metadata.</summary>
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        ///<summary>A list of metadata key/values to remove in the object. It is not an error for a provided key to not exist. If a provided key exists but doesn't match the provided value, it will not be removed.</summary>
        [JsonProperty("remove_metadata")]
        public Metadata? RemoveMetadata { get; set; }

        ///<summary>Remove the supplied password from the file.</summary>
        [JsonProperty("remove_password")]
        public string? RemovePassword { get; set; }

        ///<summary>A list of tags to remove. It is not an error to provide a tag which is not present.</summary>
        [JsonProperty("remove_tags")]
        public Tags? RemoveTags { get; set; }

        ///<summary>Set the parent (folder) of the object. Can be an empty string for the root folder.</summary>
        [JsonProperty("parent_id")]
        public string? ParentID { get; set; }

        ///<summary>Set the object's tags.</summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        ///<summary>The date and time the object was last updated. If included, the update will fail if this doesn't match the date and time of the last update for the object.</summary>
        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; }

        /// <summary>The bucket to use, if not the default.</summary>
        [JsonProperty("bucket_id")]
        public string? BucketID { get; set; }
    }
}

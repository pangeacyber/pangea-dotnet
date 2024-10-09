using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class CommonStoreRequest : BaseRequest
    {
        /// <summary>
        /// The name of this item
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The folder where this item is stored
        /// </summary>
        [JsonProperty("folder")]
        public string? Folder { get; set; }

        /// <summary>
        /// User-provided metadata
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        /// <summary>
        /// A list of user-defined tags
        /// </summary>
        [JsonProperty("tags")]
        public Tags? Tags { get; set; }

        /// <summary>
        /// Period of time between item rotations.
        /// </summary>
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        /// <summary>
        /// State to which the previous version should transition upon rotation
        /// </summary>
        [JsonProperty("rotation_state")]
        public string? RotationState { get; set; }

        /// <summary>
        /// Timestamp indicating when the item will be disabled
        /// </summary>
        [JsonProperty("disabled_at")]
        public string? DisabledAt { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the item to store</param>
        protected CommonStoreRequest(string name)
        {
            Name = name;
        }
    }
}

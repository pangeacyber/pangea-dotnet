using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class UpdateRequest : BaseRequest
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The name of this item
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The parent folder where this item is stored
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
        /// Timestamp indicating when the item will be disabled
        /// </summary>
        [JsonProperty("disabled_at")]
        public string? DisabledAt { get; set; }

        /// <summary>
        /// True if the item is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Period of time between item rotations, never to disable rotation or inherited to inherit the value from the parent folder or from the default settings (format: a positive number followed by a time period (secs, mins, hrs, days, weeks, months, years) or an abbreviation
        /// </summary>
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        /// <summary>
        /// State to which the previous version should transition upon rotation or inherited to inherit the value from the parent folder or from the default settings
        /// </summary>
        [JsonProperty("rotation_state")]
        public string? RotationState { get; set; }

        /// <summary>
        /// Grace period for the previous version of the Pangea Token or inherited to inherit the value from the parent folder or from the default settings (format: a positive number followed by a time period (secs, mins, hrs, days, weeks, months, years) or an abbreviation
        /// </summary>
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The item ID to be updated</param>
        public UpdateRequest(string id)
        {
            ID = id;
        }
    }
}

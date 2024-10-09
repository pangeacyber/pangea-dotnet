using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class CommonRotateRequest : BaseRequest
    {
        /// <summary>
        /// The ID of the key
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// State to which the previous version should transition upon rotation
        /// </summary>
        [JsonProperty("rotation_state")]
        public ItemVersionState? RotationState { get; set; }

        /// <summary>
        /// Period of time between item rotations, never to disable rotation or inherited to inherit the value from the parent folder or from the default settings (format: a positive number followed by a time period (secs, mins, hrs, days, weeks, months, years) or an abbreviation
        /// </summary>
        [JsonProperty("rotation_frequency")]
        public string? RotationFrequency { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        protected CommonRotateRequest(string id)
        {
            ID = id;
        }
    }
}

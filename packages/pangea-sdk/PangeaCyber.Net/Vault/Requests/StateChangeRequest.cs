using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class StateChangeRequest : BaseRequest
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// The new state of the item version
        /// </summary>
        [JsonProperty("state")]
        public ItemVersionState State { get; set; }

        /// <summary>
        /// Period of time for the destruction of a compromised key. Only applicable if state=compromised (format: a positive number followed by a time period (secs, mins, hrs, days, weeks, months, years) or an abbreviation
        /// </summary>
        [JsonProperty("destroy_period")]
        public string? DestroyPeriod { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The item ID</param>
        /// <param name="version">The item version</param>
        /// <param name="state">The new state of the item version</param>
        public StateChangeRequest(string id, int version, ItemVersionState state)
        {
            ID = id;
            Version = version;
            State = state;
        }
    }
}

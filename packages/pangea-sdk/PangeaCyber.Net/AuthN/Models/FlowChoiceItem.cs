using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FlowChoiceItem
    {
        /// <summary>
        /// Gets or sets the choice property.
        /// </summary>
        [JsonProperty("choice")]
        public string Choice { get; private set; } = default!;

        /// <summary>
        /// Gets or sets the data property.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, object>? Data { get; private set; }
    }
}

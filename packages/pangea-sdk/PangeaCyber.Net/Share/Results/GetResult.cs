using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    /// <summary>
    /// Represents the result of a get operation.
    /// </summary>
    public class GetResult
    {
        ///
        [JsonProperty("object")]
        public ItemData Object { get; set; } = new ItemData();

        /// <summary> A URL where the file can be downloaded from. (transfer_method: dest-url)</summary>
        [JsonProperty("dest_url")]
        public string? DestURL { get; set; }
    }
}

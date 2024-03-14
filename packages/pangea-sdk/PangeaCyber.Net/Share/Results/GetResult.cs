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

        ///
        [JsonProperty("dest_url")]
        public string? DestURL { get; set; }
    }
}

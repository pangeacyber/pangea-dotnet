using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Results
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
        public string? DestUrl { get; set; }
    }
}

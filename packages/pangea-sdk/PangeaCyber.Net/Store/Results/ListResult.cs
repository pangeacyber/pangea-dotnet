using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Results
{
    ///
    public class ListResult
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("objects")]
        public List<ItemData> Objects { get; set; } = new List<ItemData>();
    }
}

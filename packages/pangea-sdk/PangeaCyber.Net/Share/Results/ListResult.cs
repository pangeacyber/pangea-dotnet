using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
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

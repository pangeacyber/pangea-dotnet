using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Results
{
    ///
    public class ListResult
    {
        /// <summary>
        /// The total number of objects matched by the list request.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Used to fetch the next page of the current listing when provided in a repeated request's last parameter.
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }

        ///
        [JsonProperty("objects")]
        public List<ItemData> Objects { get; set; } = new List<ItemData>();
    }
}

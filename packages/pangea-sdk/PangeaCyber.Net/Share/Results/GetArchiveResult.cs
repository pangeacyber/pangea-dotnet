using Newtonsoft.Json;

using PangeaCyber.Net.Share.Models;
namespace PangeaCyber.Net.Share.Results
{
    ///
    public class GetArchiveResult
    {
        /// <summary>A location where the archive can be downloaded from. (transfer_method: dest-url)</summary>
        [JsonProperty("dest_url")]
        public string? DestUrl { get; set; }

        /// <summary>Number of objects included in the archive.</summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>A list of all objects included in the archive.</summary>
        [JsonProperty("objects")]
        public List<ItemData> Objects { get; set; } = new List<ItemData>();
    }
}

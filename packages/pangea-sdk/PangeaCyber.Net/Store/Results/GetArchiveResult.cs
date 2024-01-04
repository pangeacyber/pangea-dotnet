using Newtonsoft.Json;

namespace PangeaCyber.Net.Store.Results
{
    ///
    public class GetArchiveResult
    {
        ///
        [JsonProperty("dest_url")]
        public string? DestUrl { get; set; }

        ///
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}

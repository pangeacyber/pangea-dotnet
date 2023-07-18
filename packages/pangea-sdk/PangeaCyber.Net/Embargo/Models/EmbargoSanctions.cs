using Newtonsoft.Json;

namespace PangeaCyber.Net.Embargo
{
    ///
    public class EmbargoSanctions
    {
        ///
        [JsonProperty("count")]
        public int Count { get; set; }

        ///
        [JsonProperty("sanctions")]
        public List<EmbargoSanction>? Sanctions { get; set; }
    }
}

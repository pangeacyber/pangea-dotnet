using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IntelCommonResult
    {
        ///
        [JsonProperty("parameters")]
        public Dictionary<string, object>? Parameters { get; private set; }

        ///
        [JsonProperty("raw_data")]
        public Dictionary<string, object>? RawData { get; private set; }

    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IntelCommonResult
    {
        ///
        [JsonProperty("parameters")]
        public Dictionary<string, object>? Parameters { get; set; }

        ///
        [JsonProperty("raw_data")]
        public Dictionary<string, object>? RawData { get; set; }

        ///
        public Dictionary<string, object>? GetParameters()
        {
            return Parameters;
        }

        ///
        public Dictionary<string, object>? GetRawData()
        {
            return RawData;
        }
    }
}

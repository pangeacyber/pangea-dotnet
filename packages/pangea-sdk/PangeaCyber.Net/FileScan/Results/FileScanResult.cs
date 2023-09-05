using Newtonsoft.Json;

namespace PangeaCyber.Net.FileScan
{
    ///
    public class FileScanResult
    {
        ///
        [JsonProperty("parameters")]
        public Dictionary<string, object>? Parameters { get; set; }

        ///
        [JsonProperty("raw_data")]
        public Dictionary<string, object>? RawData { get; set; }

        ///
        [JsonProperty("data")]
        public FileScanData Data { get; set; } = new FileScanData();
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class FileScanResult : IntelCommonResult
    {
        ///
        [JsonProperty("data")]
        public FileScanData Data { get; set; } = new FileScanData();

    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.FileScan
{
    ///
    public class FileScanData
    {
        ///
        [JsonProperty("category")]
        public string[] Category { get; set; }

        ///
        [JsonProperty("score")]
        public int Score { get; set; }

        ///
        [JsonProperty("verdict")]
        public string Verdict { get; set; }

        ///
        public FileScanData()
        {
            Category = new string[] { };
            Verdict = default!;
        }
    }
}

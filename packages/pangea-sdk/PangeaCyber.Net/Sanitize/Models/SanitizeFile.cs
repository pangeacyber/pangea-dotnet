using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class SanitizeFile
    {
        ///
        [JsonProperty("scan_provider")]
        public string? ScanProvider { get; set; }

        ///
        [JsonProperty("cdr_provider")]
        public string? CDRProvider { get; set; }

        ///
        public SanitizeFile() { }
    }
}

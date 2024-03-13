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
        public SanitizeFile() { }
    }
}

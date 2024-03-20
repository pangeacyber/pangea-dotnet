using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Sanitize file.</summary>
    public class SanitizeFile
    {
        /// <summary>Provider to use for File Scan.</summary>
        [JsonProperty("scan_provider")]
        public string? ScanProvider { get; set; }

        /// <summary>Constructor.</summary>
        public SanitizeFile() { }
    }
}

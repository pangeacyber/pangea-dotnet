using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    ///
    public class ShareOutput
    {
        ///
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        ///
        [JsonProperty("output_folder")]
        public string? OutputFolder { get; set; }

        ///
        public ShareOutput() { }
    }
}

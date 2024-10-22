using Newtonsoft.Json;

namespace PangeaCyber.Net.Sanitize
{
    /// <summary>Share output.</summary>
    public class ShareOutput
    {
        /// <summary>If not enabled, a presigned URL will be returned in 'result.dest_url'.</summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>Store Sanitized files to this Secure Share folder (will be auto-created if not exists)</summary>
        [JsonProperty("output_folder")]
        public string? OutputFolder { get; set; }

        /// <summary>Constructor.</summary>
        public ShareOutput() { }
    }
}

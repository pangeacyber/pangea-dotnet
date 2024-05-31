using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// UnredactRequest
    /// </summary>
    public class UnredactRequest : BaseRequest
    {
        ///
        [JsonProperty("redacted_data")]
        public object RedactedData { get; set; }

        ///
        [JsonProperty("fpe_context")]
        public string FPEContext { get; set; }

        ///
        public UnredactRequest(object redactedData, string fpeContext)
        {
            this.RedactedData = redactedData;
            this.FPEContext = fpeContext;
        }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// UnredactRequest
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public class UnredactRequest<T> : BaseRequest
    {
        ///
        [JsonProperty("redacted_data")]
        public T RedactedData { get; set; }

        ///
        [JsonProperty("fpe_context")]
        public string FPEContext { get; set; }

        ///
        public UnredactRequest(T redactedData, string fpeContext)
        {
            this.RedactedData = redactedData;
            this.FPEContext = fpeContext;
        }
    }
}

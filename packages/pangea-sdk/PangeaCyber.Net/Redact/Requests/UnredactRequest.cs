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
        /// <summary>Data to unredact</summary>
        [JsonProperty("redacted_data")]
        public T RedactedData { get; set; }

        /// <summary>FPE context used to decrypt and unredact data</summary>
        [JsonProperty("fpe_context")]
        public string FPEContext { get; set; }

        /// <summary>Constructor.</summary>
        public UnredactRequest(T redactedData, string fpeContext)
        {
            this.RedactedData = redactedData ?? throw new ArgumentNullException(nameof(redactedData));
            this.FPEContext = fpeContext ?? throw new ArgumentNullException(nameof(fpeContext));
        }
    }
}

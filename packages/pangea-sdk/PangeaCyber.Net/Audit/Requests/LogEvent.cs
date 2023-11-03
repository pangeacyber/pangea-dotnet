using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// LogRequest
    /// </summary>
    public class LogEvent
    {
        ///
        [JsonProperty("event", Required = Required.Always)]
        public IEvent Event { get; set; } = default!;

        ///
        [JsonProperty("signature")]
        public string Signature { get; set; } = default!;

        ///
        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = default!;

        ///
        public LogEvent(IEvent evt, string signature, string publicKey)
        {
            Event = evt;
            Signature = signature;
            PublicKey = publicKey;
        }
    }
}

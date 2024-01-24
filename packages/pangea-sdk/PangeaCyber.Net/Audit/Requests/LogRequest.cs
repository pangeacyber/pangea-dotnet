using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// LogRequest
    /// </summary>
    public class LogRequest : BaseRequest
    {
        ///
        [JsonProperty("event", Required = Required.Always)]
        public IEvent @event { get; private set; } = default!;

        ///
        [JsonProperty("verbose")]
        public bool Verbose { get; private set; } = default!;

        ///
        [JsonProperty("signature")]
        public string Signature { get; private set; } = default!;

        ///
        [JsonProperty("public_key")]
        public string PublicKey { get; private set; } = default!;

        ///
        [JsonProperty("prev_root")]
        public string PrevRoot { get; private set; } = default!;

        ///
        public LogRequest(IEvent evt, bool verbose, string signature, string publicKey, string prevRoot)
        {
            @event = evt;
            Verbose = verbose;
            Signature = signature;
            PublicKey = publicKey;
            PrevRoot = prevRoot;
        }
    }
}

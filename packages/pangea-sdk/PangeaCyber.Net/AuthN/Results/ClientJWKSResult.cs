using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class ClientJWKSResult
    {
        ///
        [JsonProperty("keys")]
        public JWK[] Keys { get; private set; } = default!;

        ///
        public ClientJWKSResult() { }

    }
}

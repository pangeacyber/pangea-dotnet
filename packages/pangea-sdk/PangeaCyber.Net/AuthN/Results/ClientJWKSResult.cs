using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
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

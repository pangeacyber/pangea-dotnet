using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class JWKGetResult
    {
        ///
        [JsonProperty("keys")]
        public JWK[] Keys { get; set; } = default!;

        ///
        public JWKGetResult()
        {
        }
    }
}

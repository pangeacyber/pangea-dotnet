using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Results
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

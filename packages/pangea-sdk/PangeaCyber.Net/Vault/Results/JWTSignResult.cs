using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class JWTSignResult
    {
        ///
        [JsonProperty("jws")]
        public string JWS { get; set; } = default!;

        ///
        public JWTSignResult()
        {
        }
    }
}

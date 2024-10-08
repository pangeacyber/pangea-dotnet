using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class JWKGetResult
    {
        /// <summary>
        /// The JSON Web Key Set (JWKS) object. Fields with key information are base64URL encoded.
        /// </summary>
        [JsonProperty("keys")]
        public JWK[] Keys { get; set; } = default!;

    }
}

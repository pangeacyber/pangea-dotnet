using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class JWTSignResult
    {
        /// <summary>
        /// The signed JSON Web Token (JWS)
        /// </summary>
        [JsonProperty("jws")]
        public string JWS { get; set; } = default!;

    }
}

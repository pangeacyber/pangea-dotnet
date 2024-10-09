using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class JWTVerifyResult
    {
        /// <summary>
        /// Indicates if messages have been verified.
        /// </summary>
        [JsonProperty("valid_signature")]
        public bool ValidSignature { get; set; }

    }
}

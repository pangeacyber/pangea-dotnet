using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class JWTVerifyResult
    {
        ///
        [JsonProperty("valid_signature")]
        public bool ValidSignature { get; set; }

        ///
        public JWTVerifyResult()
        {
        }

    }
}

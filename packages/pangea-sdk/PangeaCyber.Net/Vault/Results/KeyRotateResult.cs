using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class KeyRotateResult : CommonRotateResult
    {
        ///
        [JsonProperty("public_key")]
        public string EncodedPublicKey { get; set; } = default!;

        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        [JsonProperty("purpose")]
        public string Purpose { get; set; } = default!;

        ///
        public KeyRotateResult()
        {
        }
    }
}

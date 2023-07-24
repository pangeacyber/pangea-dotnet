using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class AsymmetricGenerateResult : CommonGenerateResult
    {
        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        [JsonProperty("purpose")]
        public string Purpose { get; set; } = default!;

        ///
        [JsonProperty("public_key")]
        public string EncodedPublicKey { get; set; } = default!;

        ///
        public AsymmetricGenerateResult()
        {
        }
    }
}

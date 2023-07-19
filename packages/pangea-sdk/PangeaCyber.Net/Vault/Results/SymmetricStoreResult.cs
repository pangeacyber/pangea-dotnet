using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SymmetricStoreResult : CommonStoreResult
    {
        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        [JsonProperty("purpose")]
        public string Purpose { get; set; } = default!;

        ///
        public SymmetricStoreResult()
        {
        }
    }
}

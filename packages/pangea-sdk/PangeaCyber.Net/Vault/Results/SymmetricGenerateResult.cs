using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SymmetricGenerateResult : CommonGenerateResult
    {
        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        [JsonProperty("purpose")]
        public string Purpose { get; set; } = default!;

        ///
        public SymmetricGenerateResult()
        {
        }
    }
}

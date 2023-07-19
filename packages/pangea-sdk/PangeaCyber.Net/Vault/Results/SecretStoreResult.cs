using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SecretStoreResult : CommonStoreResult
    {
        ///
        [JsonProperty("secret")]
        public string Secret { get; set; } = default!;

        ///
        public SecretStoreResult()
        {
        }
    }
}

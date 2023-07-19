using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SecretRotateResult : CommonRotateResult
    {
        ///
        [JsonProperty("secret")]
        public string Secret { get; set; } = default!;

        ///
        public SecretRotateResult()
        {
        }
    }
}

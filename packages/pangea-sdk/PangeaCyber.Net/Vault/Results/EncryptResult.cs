using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class EncryptResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int Version { get; set; }

        ///
        [JsonProperty("cipher_text")]
        public string CipherText { get; set; } = default!;

        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        public EncryptResult()
        {
        }
    }
}

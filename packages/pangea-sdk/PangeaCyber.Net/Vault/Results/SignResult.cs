using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SignResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int Version { get; set; }

        ///
        [JsonProperty("signature")]
        public string Signature { get; set; } = default!;

        ///
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        ///
        [JsonProperty("public_key")]
        public string EncodedPublicKey { get; set; } = default!;

        ///
        public SignResult()
        {
        }

    }
}

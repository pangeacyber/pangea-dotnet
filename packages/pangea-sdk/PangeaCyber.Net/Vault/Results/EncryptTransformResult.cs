using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    /// <summary>Result of an encrypt transform request.</summary>
    public sealed class EncryptTransformResult : BaseRequest
    {
        /// <summary>The ID of the item.</summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>The item version.</summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>The algorithm of the key.</summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }

        /// <summary>The encrypted message.</summary>
        [JsonProperty("cipher_text")]
        public string CipherText { get; set; }

        /// <summary>Constructor.</summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="version">The item version.</param>
        /// <param name="algorithm">The algorithm of the key.</param>
        /// <param name="cipherText">The encrypted message.</param>
        public EncryptTransformResult(string id, int version, string algorithm, string cipherText)
        {
            this.ID = id;
            this.Version = version;
            this.Algorithm = algorithm;
            this.CipherText = cipherText;
        }
    }
}

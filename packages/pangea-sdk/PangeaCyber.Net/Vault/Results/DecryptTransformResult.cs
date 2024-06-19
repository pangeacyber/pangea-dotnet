using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    /// <summary>Result of an decrypt transform request.</summary>
    public sealed class DecryptTransformResult
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

        /// <summary>Decrypted message.</summary>
        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

        /// <summary>Constructor.</summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="version">The item version.</param>
        /// <param name="algorithm">The algorithm of the key.</param>
        /// <param name="plainText">The encrypted message.</param>
        public DecryptTransformResult(string id, int version, string algorithm, string plainText)
        {
            this.ID = id;
            this.Version = version;
            this.Algorithm = algorithm;
            this.PlainText = plainText;
        }
    }
}

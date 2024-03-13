using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

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

        /// <summary>
        /// User provided tweak string. If not provided, a random string will be generated and returned. The user must
        /// securely store the tweak source which will be needed to decrypt the data.
        /// </summary>
        [JsonProperty("tweak")]
        public string Tweak { get; set; }

        /// <summary>Set of characters to use for format-preserving encryption (FPE).</summary>
        [JsonProperty("alphabet")]
        public TransformAlphabet Alphabet { get; set; } = default!;

        /// <summary>Constructor.</summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="version">The item version.</param>
        /// <param name="algorithm">The algorithm of the key.</param>
        /// <param name="cipherText">The encrypted message.</param>
        /// <param name="tweak">User-provided tweak, which must be a base64-encoded 7-digit string.</param>
        /// <param name="alphabet">Set of characters to use for format-preserving encryption (FPE).</param>
        public EncryptTransformResult(string id, int version, string algorithm, string cipherText, string tweak, TransformAlphabet alphabet)
        {
            this.ID = id;
            this.Version = version;
            this.Algorithm = algorithm;
            this.CipherText = cipherText;
            this.Tweak = tweak;
            this.Alphabet = alphabet;
        }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    /// <summary>Parameters for an decrypt transform request.</summary>
    public sealed class DecryptTransformRequest : BaseRequest
    {
        /// <summary>The ID of the key to use.</summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>A message encrypted by Vault.</summary>
        [JsonProperty("cipher_text")]
        public string CipherText { get; set; }

        /// <summary>User-provided tweak, which must be a base64-encoded 7-digit string.</summary>
        [JsonProperty("tweak")]
        public string Tweak { get; set; }

        /// <summary>Set of characters to use for format-preserving encryption (FPE).</summary>
        [JsonProperty("alphabet")]
        public TransformAlphabet Alphabet { get; set; }

        /// <summary>The item version. Defaults to the current version.</summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>Constructor.</summary>
        /// <param name="id">The ID of the key to use.</param>
        /// <param name="cipherText">A message encrypted by Vault.</param>
        /// <param name="tweak">User-provided tweak, which must be a base64-encoded 7-digit string.</param>
        /// <param name="alphabet">Set of characters to use for format-preserving encryption (FPE).</param>
        /// <param name="version">The item version. Defaults to the current version.</param>
        public DecryptTransformRequest(string id, string cipherText, string tweak, TransformAlphabet alphabet, int? version)
        {
            this.ID = id;
            this.CipherText = cipherText;
            this.Tweak = tweak;
            this.Alphabet = alphabet;
            this.Version = version;
        }
    }
}

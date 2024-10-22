using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    /// <summary>Parameters for an encrypt transform request.</summary>
    public sealed class EncryptTransformRequest : BaseRequest
    {
        /// <summary>The ID of the key to use.</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>Message to be encrypted.</summary>
        [JsonProperty("plain_text")]
        public string PlainText { get; set; } = default!;

        /// <summary>
        /// User provided tweak string. If not provided, a random string will be generated and returned. The user must
        /// securely store the tweak source which will be needed to decrypt the data.
        /// </summary>
        [JsonProperty("tweak")]
        public string? Tweak { get; set; }

        /// <summary>Set of characters to use for format-preserving encryption (FPE).</summary>
        [JsonProperty("alphabet")]
        public TransformAlphabet Alphabet { get; set; } = default!;

        /// <summary>The item version. Defaults to the current version.</summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>Constructor.</summary>
        public EncryptTransformRequest() { }
    }
}

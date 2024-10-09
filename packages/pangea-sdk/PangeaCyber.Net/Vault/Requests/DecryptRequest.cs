using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class DecryptRequest : BaseRequest
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// A message encrypted by Vault (Base64 encoded)
        /// </summary>
        [JsonProperty("cipher_text")]
        public string CipherText { get; set; }

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>
        /// User provided authentication data
        /// </summary>
        [JsonProperty("additional_data")]
        public string? AdditionalData { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The item ID to decrypt with</param>
        /// <param name="cipherText">Encrypted message to decrypt</param>
        public DecryptRequest(string id, string cipherText)
        {
            ID = id;
            CipherText = cipherText;
        }
    }
}

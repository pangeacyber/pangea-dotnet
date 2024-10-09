using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class EncryptRequest : BaseRequest
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// A message to be encrypted (Base64 encoded)
        /// </summary>
        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

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
        /// <param name="id"></param>
        /// <param name="plainText"></param>
        public EncryptRequest(string id, string plainText)
        {
            ID = id;
            PlainText = plainText;
        }
    }
}

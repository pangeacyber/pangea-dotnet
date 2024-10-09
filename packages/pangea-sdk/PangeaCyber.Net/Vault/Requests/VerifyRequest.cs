using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class VerifyRequest : BaseRequest
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// A message to be verified
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The message signature
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The ID of the item</param>
        /// <param name="message">A message to be verified</param>
        /// <param name="signature">The message signature</param>
        public VerifyRequest(string id, string message, string signature)
        {
            ID = id;
            Message = message;
            Signature = signature;
        }
    }
}

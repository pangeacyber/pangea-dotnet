using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SignRequest : BaseRequest
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The message to be signed
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The ID of the item</param>
        /// <param name="message">The message to be signed</param>
        public SignRequest(string id, string message)
        {
            ID = id;
            Message = message;
        }
    }
}

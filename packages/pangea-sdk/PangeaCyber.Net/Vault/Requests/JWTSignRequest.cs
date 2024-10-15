using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class JWTSignRequest : BaseRequest
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The JWT payload (in JSON)
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The item ID</param>
        /// <param name="payload">The JWT payload (in JSON)</param>
        public JWTSignRequest(string id, string payload)
        {
            ID = id;
            Payload = payload;
        }

    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class JWKGetRequest : BaseRequest
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The key version(s). all for all versions, num for a specific version, -num for the num latest versions
        /// </summary>
        [JsonProperty("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public JWKGetRequest(string id)
        {
            ID = id;
        }
    }
}

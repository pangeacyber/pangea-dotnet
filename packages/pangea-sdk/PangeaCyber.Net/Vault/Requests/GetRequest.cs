using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class GetRequest : BaseRequest
    {
        /// <summary>
        /// The ID of the item
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// The item version
        /// </summary>
        [JsonProperty("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The ID of the item</param>
        public GetRequest(string id)
        {
            ID = id;
        }
    }
}

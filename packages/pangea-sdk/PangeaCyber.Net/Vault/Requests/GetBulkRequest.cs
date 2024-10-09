using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class GetBulkRequest : BaseRequest
    {
        /// <summary>
        /// A set of filters to help you customize your search.
        /// </summary>
        [JsonProperty("filter")]
        public Dictionary<string, string>? Filter { get; set; }

        /// <summary>
        /// Internal ID returned in the previous look up response. Used for pagination.
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }

        /// <summary>
        /// Maximum number of items in the response
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// Ordering direction
        /// </summary>
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        /// <summary>
        /// Property used to order the results
        /// </summary>
        [JsonProperty("order_by")]
        public ItemOrderBy? OrderBy { get; set; }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Store.Models;

namespace PangeaCyber.Net.Store.Requests
{
    ///
    public class ListRequest : BaseRequest
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("filter")]
        public FilterList? Filter { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("last")]
        public string? Last { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("order_by")]
        public ItemOrderBy? OrderBy { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }
    }
}

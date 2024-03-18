using Newtonsoft.Json;
using PangeaCyber.Net.Share.Models;

namespace PangeaCyber.Net.Share.Requests
{
    ///
    public class ShareLinkListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public FilterShareLinkList Filter { get; set; } = new FilterShareLinkList();

        ///
        [JsonProperty("last")]
        public string Last { get; set; } = default!;

        ///
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("order_by")]
        public ShareLinkOrderBy? OrderBy { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; set; }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.AuthZ.Models;

namespace PangeaCyber.Net.AuthZ.Requests
{
    ///
    public class TupleListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public FilterTupleList? Filter { get; set; }

        ///
        [JsonProperty("last")]
        public string? Last { get; set; }

        ///
        [JsonProperty("order")]
        public ItemOrder? Order { get; set; }

        ///
        [JsonProperty("order_by")]
        public TupleOrderBy? OrderBy { get; set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; set; }

        ///
        public TupleListRequest()
        {
        }
    }
}

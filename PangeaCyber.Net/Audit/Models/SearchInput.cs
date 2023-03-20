using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{

    /// <kind>class</kind>
    /// <summary>
    /// SearchInput
    /// </summary>
    public class SearchInput
    {
        ///
        [JsonProperty("query", Required = Required.Always)]
        public string Query { get; set; } = default!;

        ///
        [JsonProperty("order")]
        public string Order { get; set; } = default!;

        ///
        [JsonProperty("order_by", NullValueHandling = NullValueHandling.Ignore )]
        public string OrderBy { get; set; } = default!;

        ///
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public string Start { get; set; } = default!;

        ///
        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public string End { get; set; } = default!;

        ///
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Limit { get; set; } = default!;

        ///
        [JsonProperty("max_results", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxResults { get; set; } = default!;

        ///
        [JsonProperty("search_restriction", NullValueHandling = NullValueHandling.Ignore)]
        public SearchRestriction SearchRestriction { get; set; } = default!;

        ///
        [JsonProperty("verbose", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Verbose { get; set; } = default!;

        ///
        public SearchInput(string query)
        {
            this.Query = query;
        }
    }
}

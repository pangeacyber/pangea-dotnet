using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    ///
    public class SearchRequest : BaseRequest
    {
        ///
        [JsonProperty("query")]
        public string Query { get; }

        ///
        [JsonProperty("order")]
        public string? Order { get; }

        ///
        [JsonProperty("order_by")]
        public string? OrderBy { get; }

        ///
        [JsonProperty("start")]
        public string? Start { get; }

        ///
        [JsonProperty("end")]
        public string? End { get; }

        ///
        [JsonProperty("limit")]
        public int? Limit { get; }

        ///
        [JsonProperty("max_results")]
        public int? MaxResults { get; }

        ///
        [JsonProperty("search_restriction")]
        public SearchRestriction? SearchRestriction { get; }

        ///
        [JsonProperty("verbose")]
        public bool? Verbose { get; set; }

        /// <summary>Return the context data needed to decrypt secure audit events that have been redacted with format preserving encryption.</summary>
        [JsonProperty("return_context")]
        public bool? ReturnContext { get; set; }

        ///
        private SearchRequest(Builder builder)
        {
            Query = builder.Query;
            Order = builder.Order;
            OrderBy = builder.OrderBy;
            Start = builder.Start;
            End = builder.End;
            Limit = builder.Limit;
            MaxResults = builder.MaxResults;
            SearchRestriction = builder.SearchRestriction;
            Verbose = builder.Verbose;
            ReturnContext = builder.ReturnContext;
        }

        ///
        public class Builder
        {
            ///
            public string Query { get; }
            ///
            public string? Order { get; set; }
            ///
            public string? OrderBy { get; set; }
            ///
            public string? Start { get; set; }
            ///
            public string? End { get; set; }
            ///
            public int? Limit { get; set; }
            ///
            public int? MaxResults { get; set; }
            ///
            public SearchRestriction? SearchRestriction { get; set; }
            ///
            public bool? Verbose { get; set; }
            ///
            public bool? ReturnContext { get; set; }

            ///
            public Builder(string query)
            {
                Query = query;
            }

            ///
            public Builder WithOrder(string order)
            {
                Order = order;
                return this;
            }

            ///
            public Builder WithOrderBy(string orderBy)
            {
                OrderBy = orderBy;
                return this;
            }

            ///
            public Builder WithStart(string start)
            {
                Start = start;
                return this;
            }

            ///
            public Builder WithEnd(string end)
            {
                End = end;
                return this;
            }

            ///
            public Builder WithLimit(int? limit)
            {
                Limit = limit;
                return this;
            }

            ///
            public Builder WithMaxResults(int? maxResults)
            {
                MaxResults = maxResults;
                return this;
            }

            ///
            public Builder WithSearchRestriction(SearchRestriction searchRestriction)
            {
                SearchRestriction = searchRestriction;
                return this;
            }

            ///
            public Builder WithVerbose(bool? verbose)
            {
                Verbose = verbose;
                return this;
            }

            ///
            public Builder WithReturnContext(bool rc)
            {
                ReturnContext = rc;
                return this;
            }

            ///
            public SearchRequest Build()
            {
                return new SearchRequest(this);
            }
        }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class CommonSessionListRequest<TBuilder> : BaseRequest where TBuilder : CommonSessionListRequest<TBuilder>.CommonBuilder
    {
        ///
        [JsonProperty("filter")]
        public FilterSessionList? Filter { get; set; }

        ///
        [JsonProperty("last")]
        public string? Last { get; set; }

        ///
        [JsonProperty("order")]
        public ListOrder? Order { get; set; }

        ///
        [JsonProperty("order_by")]
        public SessionOrderBy? OrderBy { get; set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; set; }

        ///
        protected CommonSessionListRequest(CommonBuilder builder)
        {
            Filter = builder.Filter;
            Last = builder.Last;
            Order = builder.Order;
            OrderBy = builder.OrderBy;
            Size = builder.Size;
        }

        ///
        public class CommonBuilder
        {
            ///
            public FilterSessionList? Filter { get; private set; }
            ///
            public string? Last { get; private set; }
            ///
            public ListOrder? Order { get; private set; }
            ///
            public SessionOrderBy? OrderBy { get; private set; }
            ///
            public int? Size { get; private set; }

            ///
            public CommonBuilder() { }

            ///
            public CommonSessionListRequest<TBuilder> Build()
            {
                return new CommonSessionListRequest<TBuilder>((TBuilder)this);
            }

            /// @deprecated use WithFilter(FilterSessionList filter) instead
            public TBuilder WithFilter(Filter filter)
            {
                Filter = new FilterSessionList();
                foreach (var kvp in filter)
                {
                    Filter.Add(kvp.Key, kvp.Value);
                }
                return (TBuilder)this;
            }

            ///
            public TBuilder WithFilter(FilterSessionList filter)
            {
                Filter = new FilterSessionList();
                foreach (var kvp in filter)
                {
                    Filter.Add(kvp.Key, kvp.Value);
                }
                return (TBuilder)this;
            }

            ///
            public TBuilder WithLast(string last)
            {
                Last = last;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithOrder(ListOrder order)
            {
                Order = order;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithOrderBy(SessionOrderBy orderBy)
            {
                OrderBy = orderBy;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithSize(int? size)
            {
                Size = size;
                return (TBuilder)this;
            }
        }
    }
}

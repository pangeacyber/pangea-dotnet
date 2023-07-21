using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class CommonSessionListRequest<TBuilder> : BaseRequest where TBuilder : CommonSessionListRequest<TBuilder>.CommonBuilder
    {
        ///
        [JsonProperty("filter")]
        public Filter? Filter { get; set; }

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
            this.Filter = builder.Filter;
            this.Last = builder.Last;
            this.Order = builder.Order;
            this.OrderBy = builder.OrderBy;
            this.Size = builder.Size;
        }

        ///
        public class CommonBuilder
        {
            ///
            public Filter? Filter { get; private set; }
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

            ///
            public TBuilder WithFilter(Filter filter)
            {
                this.Filter = filter;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithLast(string last)
            {
                this.Last = last;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithOrder(ListOrder order)
            {
                this.Order = order;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithOrderBy(SessionOrderBy orderBy)
            {
                this.OrderBy = orderBy;
                return (TBuilder)this;
            }

            ///
            public TBuilder WithSize(int? size)
            {
                this.Size = size;
                return (TBuilder)this;
            }
        }
    }
}

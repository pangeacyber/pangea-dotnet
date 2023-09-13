using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models; // Import ListOrder and AgreementListOrderBy from appropriate namespace

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class AgreementListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public Dictionary<string, string>? Filter { get; private set; }

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        [JsonProperty("order")]
        public ListOrder? Order { get; private set; }

        ///
        [JsonProperty("order_by")]
        public AgreementListOrderBy? OrderBy { get; private set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; private set; }

        private AgreementListRequest(Builder builder)
        {
            this.Filter = builder.Filter;
            this.Last = builder.Last;
            this.Order = builder.Order;
            this.OrderBy = builder.OrderBy;
            this.Size = builder.Size;
        }

        ///
        public class Builder
        {
            ///
            public Dictionary<string, string>? Filter { get; private set; }
            ///
            public string? Last { get; private set; }
            ///
            public ListOrder? Order { get; private set; }
            ///
            public AgreementListOrderBy? OrderBy { get; private set; }
            ///
            public int? Size { get; private set; }

            ///
            public Builder() { }

            ///
            public AgreementListRequest Build()
            {
                return new AgreementListRequest(this);
            }

            ///
            public Builder WithFilter(Dictionary<string, string> filter)
            {
                this.Filter = filter;
                return this;
            }

            ///
            public Builder WithLast(string last)
            {
                this.Last = last;
                return this;
            }

            ///
            public Builder WithOrder(ListOrder order)
            {
                this.Order = order;
                return this;
            }

            ///
            public Builder WithOrderBy(AgreementListOrderBy orderBy)
            {
                this.OrderBy = orderBy;
                return this;
            }

            ///
            public Builder WithSize(int? size)
            {
                this.Size = size;
                return this;
            }
        }
    }
}

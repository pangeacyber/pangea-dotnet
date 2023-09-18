using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models; // Import ListOrder and AgreementListOrderBy from appropriate namespace

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class AgreementListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public FilterAgreementList? Filter { get; private set; }

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
            Filter = builder.Filter;
            Last = builder.Last;
            Order = builder.Order;
            OrderBy = builder.OrderBy;
            Size = builder.Size;
        }

        ///
        public class Builder
        {
            ///
            public FilterAgreementList? Filter { get; private set; }
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

            /// @deprecated user WithFilter(FilterAgreementList filter) instead
            public Builder WithFilter(Dictionary<string, string> filter)
            {
                Filter = new FilterAgreementList();
                foreach (var kvp in filter)
                {
                    Filter.Add(kvp.Key, kvp.Value);
                }
                return this;
            }

            ///
            public Builder WithFilter(FilterAgreementList filter)
            {
                Filter = new FilterAgreementList();
                foreach (var kvp in filter)
                {
                    Filter.Add(kvp.Key, kvp.Value);
                }
                return this;
            }

            ///
            public Builder WithLast(string last)
            {
                Last = last;
                return this;
            }

            ///
            public Builder WithOrder(ListOrder order)
            {
                Order = order;
                return this;
            }

            ///
            public Builder WithOrderBy(AgreementListOrderBy orderBy)
            {
                OrderBy = orderBy;
                return this;
            }

            ///
            public Builder WithSize(int? size)
            {
                Size = size;
                return this;
            }
        }
    }
}

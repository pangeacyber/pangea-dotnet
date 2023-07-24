using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class ListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public Dictionary<string, string>? Filter { get; private set; }

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; private set; }

        ///
        [JsonProperty("order")]
        public ItemOrder? Order { get; private set; }

        ///
        [JsonProperty("order_by")]
        public ItemOrderBy? OrderBy { get; private set; }

        ///
        protected ListRequest(Builder builder)
        {
            Filter = builder.Filter;
            Last = builder.Last;
            Size = builder.Size;
            Order = builder.Order;
            OrderBy = builder.OrderBy;
        }

        ///
        public class Builder
        {
            ///
            public Dictionary<string, string>? Filter { get; private set; }
            ///
            public string? Last { get; private set; }
            ///
            public int? Size { get; private set; }
            ///
            public ItemOrder? Order { get; private set; }
            ///
            public ItemOrderBy? OrderBy { get; private set; }

            ///
            public Builder() { }

            ///
            public ListRequest Build()
            {
                return new ListRequest(this);
            }

            ///
            public Builder WithFilter(Dictionary<string, string> filter)
            {
                Filter = filter;
                return this;
            }

            ///
            public Builder WithLast(string last)
            {
                Last = last;
                return this;
            }

            ///
            public Builder WithSize(int size)
            {
                Size = size;
                return this;
            }

            ///
            public Builder WithOrder(ItemOrder order)
            {
                Order = order;
                return this;
            }

            ///
            public Builder WithOrderBy(ItemOrderBy orderBy)
            {
                OrderBy = orderBy;
                return this;
            }
        }
    }
}

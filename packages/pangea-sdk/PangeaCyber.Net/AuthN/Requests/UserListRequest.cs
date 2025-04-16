using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public FilterUserList? Filter { get; private set; }

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        [JsonProperty("order")]
        public ItemOrder? Order { get; private set; }

        ///
        [JsonProperty("order_by")]
        public UserListOrderBy? OrderBy { get; private set; }

        ///
        [JsonProperty("size")]
        public int? Size { get; private set; }

        private UserListRequest(Builder builder)
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
            public FilterUserList? Filter { get; private set; }
            ///
            public string? Last { get; private set; }
            ///
            public ItemOrder? Order { get; private set; }
            ///
            public UserListOrderBy? OrderBy { get; private set; }
            ///
            public int? Size { get; private set; }

            ///
            public Builder() { }

            ///
            public Builder WithFilter(FilterUserList filter)
            {
                Filter = new FilterUserList();
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
            public Builder WithOrder(ItemOrder order)
            {
                Order = order;
                return this;
            }

            ///
            public Builder WithOrderBy(UserListOrderBy orderBy)
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

            ///
            public UserListRequest Build()
            {
                return new UserListRequest(this);
            }
        }
    }
}

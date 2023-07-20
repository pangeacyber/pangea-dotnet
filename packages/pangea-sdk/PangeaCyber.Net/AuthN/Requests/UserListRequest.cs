using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserListRequest : BaseRequest
    {
        ///
        [JsonProperty("filter")]
        public Filter? Filter { get; private set; }

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
            public Filter? Filter { get; private set; }
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
            public Builder WithFilter(Filter filter)
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
            public Builder WithOrder(ItemOrder order)
            {
                this.Order = order;
                return this;
            }

            ///
            public Builder WithOrderBy(UserListOrderBy orderBy)
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

            ///
            public UserListRequest Build()
            {
                return new UserListRequest(this);
            }
        }
    }
}

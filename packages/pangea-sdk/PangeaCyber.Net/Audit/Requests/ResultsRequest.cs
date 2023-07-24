using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    ///
    public class ResultRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string Id { get; }

        ///
        [JsonProperty("limit")]
        public int? Limit { get; }

        ///
        [JsonProperty("offset")]
        public int? Offset { get; }

        private ResultRequest(Builder builder)
        {
            Id = builder.Id;
            Limit = builder.Limit;
            Offset = builder.Offset;
        }

        ///
        public class Builder
        {
            ///
            public string Id { get; }
            ///
            public int? Limit { get; private set; }
            ///
            public int? Offset { get; private set; }

            ///
            public Builder(string id)
            {
                Id = id;
            }

            ///
            public Builder WithLimit(int? limit)
            {
                Limit = limit;
                return this;
            }

            ///
            public Builder WithOffset(int? offset)
            {
                Offset = offset;
                return this;
            }

            ///
            public ResultRequest Build()
            {
                return new ResultRequest(this);
            }
        }
    }
}

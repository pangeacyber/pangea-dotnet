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

        /// <summary>Return the context data needed to decrypt secure audit events that have been redacted with format preserving encryption.</summary>
        [JsonProperty("return_context")]
        public bool? ReturnContext { get; set; }

        private ResultRequest(Builder builder)
        {
            Id = builder.Id;
            Limit = builder.Limit;
            Offset = builder.Offset;
            ReturnContext = builder.ReturnContext;
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
            public bool? ReturnContext { get; set; }

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
            public Builder WithReturnContext(bool? rc)
            {
                ReturnContext = rc;
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

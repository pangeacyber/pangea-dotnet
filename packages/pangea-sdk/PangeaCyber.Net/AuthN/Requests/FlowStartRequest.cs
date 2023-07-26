using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class FlowStartRequest : BaseRequest
    {
        ///
        [JsonProperty("cb_uri")]
        public string? CBUri { get; private set; }

        ///
        [JsonProperty("email")]
        public string? Email { get; private set; }

        ///
        [JsonProperty("flow_types")]
        public FlowType? FlowType { get; private set; }

        ///
        [JsonProperty("provider")]
        public IDProvider? Provider { get; private set; }

        private FlowStartRequest(Builder builder)
        {
            this.CBUri = builder.CBUri;
            this.Email = builder.Email;
            this.FlowType = builder.FlowType;
            this.Provider = builder.Provider;
        }

        ///
        public class Builder
        {
            ///
            public string? CBUri { get; private set; }
            ///
            public string? Email { get; private set; }
            ///
            public FlowType? FlowType { get; private set; }
            ///
            public IDProvider? Provider { get; private set; }

            ///
            public Builder() { }

            ///
            public Builder WithCBUri(string cbUri)
            {
                this.CBUri = cbUri;
                return this;
            }

            ///
            public Builder WithEmail(string email)
            {
                this.Email = email;
                return this;
            }

            ///
            public Builder WithFlowType(FlowType flowType)
            {
                this.FlowType = flowType;
                return this;
            }

            ///
            public Builder WithProvider(IDProvider provider)
            {
                this.Provider = provider;
                return this;
            }

            ///
            public FlowStartRequest Build()
            {
                return new FlowStartRequest(this);
            }
        }
    }
}

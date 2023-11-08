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
        public FlowType[]? FlowType { get; private set; }

        ///
        [JsonProperty("invitation")]
        public string? Invitation { get; private set; }

        private FlowStartRequest(Builder builder)
        {
            CBUri = builder.CBUri;
            Email = builder.Email;
            FlowType = builder.FlowType;
            Invitation = builder.Invitation;
        }

        ///
        public class Builder
        {
            ///
            public string? CBUri { get; private set; }
            ///
            public string? Email { get; private set; }
            ///
            public FlowType[]? FlowType { get; private set; }
            ///
            public string? Invitation { get; private set; }

            ///
            public Builder() { }

            ///
            public Builder WithCBUri(string cbUri)
            {
                CBUri = cbUri;
                return this;
            }

            ///
            public Builder WithEmail(string email)
            {
                Email = email;
                return this;
            }

            ///
            public Builder WithFlowType(FlowType[] flowType)
            {
                FlowType = flowType;
                return this;
            }

            ///
            public Builder WithInvitation(string invitation)
            {
                Invitation = invitation;
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

using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class FlowVerifyEmailRequest : BaseRequest
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; set; }

        ///
        [JsonProperty("cb_state")]
        public string? CBState { get; set; }

        ///
        [JsonProperty("cb_code")]
        public string? CBCode { get; set; }

        private FlowVerifyEmailRequest(Builder builder)
        {
            this.FlowID = builder.FlowID;
            this.CBState = builder.CBState;
            this.CBCode = builder.CBCode;
        }

        ///
        public class Builder
        {
            ///
            public string FlowID { get; private set; }
            ///
            public string? CBState { get; private set; }
            ///
            public string? CBCode { get; private set; }

            ///
            public Builder(string flowID)
            {
                this.FlowID = flowID;
            }

            ///
            public Builder WithCBState(string cbState)
            {
                this.CBState = cbState;
                return this;
            }

            ///
            public Builder WithCBCode(string cbCode)
            {
                this.CBCode = cbCode;
                return this;
            }

            ///
            public FlowVerifyEmailRequest Build()
            {
                return new FlowVerifyEmailRequest(this);
            }
        }
    }
}

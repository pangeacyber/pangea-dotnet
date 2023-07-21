using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowVerifySocialRequest : BaseRequest
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; }

        ///
        [JsonProperty("cb_state")]
        public string? CBState { get; private set; }

        ///
        [JsonProperty("cb_code")]
        public string? CBCode { get; private set; }

        ///
        protected FlowVerifySocialRequest(Builder builder)
        {
            FlowID = builder.FlowID;
            CBState = builder.CBState;
            CBCode = builder.CBCode;
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
                FlowID = flowID;
            }

            ///
            public Builder WithCBState(string cbState)
            {
                CBState = cbState;
                return this;
            }

            ///
            public Builder WithCBCode(string cbCode)
            {
                CBCode = cbCode;
                return this;
            }

            ///
            public FlowVerifySocialRequest Build()
            {
                return new FlowVerifySocialRequest(this);
            }
        }
    }
}

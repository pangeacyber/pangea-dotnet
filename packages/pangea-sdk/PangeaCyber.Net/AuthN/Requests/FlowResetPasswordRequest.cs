using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class FlowResetPasswordRequest : BaseRequest
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; }

        ///
        [JsonProperty("password")]
        public string Password { get; private set; }

        ///
        [JsonProperty("cancel")]
        public bool? Cancel { get; private set; }

        ///
        [JsonProperty("cb_state")]
        public string? CBState { get; private set; }

        ///
        [JsonProperty("cb_code")]
        public string? CBCode { get; private set; }

        private FlowResetPasswordRequest(Builder builder)
        {
            this.FlowID = builder.FlowID;
            this.Password = builder.Password;
            this.Cancel = builder.Cancel;
            this.CBState = builder.CBState;
            this.CBCode = builder.CBCode;
        }

        ///
        public class Builder
        {
            ///
            public string FlowID { get; private set; }
            ///
            public string Password { get; private set; }
            ///
            public bool? Cancel { get; private set; }
            ///
            public string? CBState { get; private set; }
            ///
            public string? CBCode { get; private set; }

            ///
            public Builder(string flowID, string password)
            {
                this.FlowID = flowID;
                this.Password = password;
            }

            ///
            public FlowResetPasswordRequest Build()
            {
                return new FlowResetPasswordRequest(this);
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
            public Builder WithCancel(bool? cancel)
            {
                this.Cancel = cancel;
                return this;
            }
        }
    }
}

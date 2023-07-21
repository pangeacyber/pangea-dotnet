using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class FlowVerifyPasswordRequest : BaseRequest
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; }

        ///
        [JsonProperty("password")]
        public string Password { get; private set; }

        ///
        [JsonProperty("reset")]
        public bool? Reset { get; private set; }

        private FlowVerifyPasswordRequest(Builder builder)
        {
            this.FlowID = builder.FlowID;
            this.Password = builder.Password;
            this.Reset = builder.Reset;
        }

        ///
        public class Builder
        {
            ///
            public string FlowID { get; private set; }
            ///
            public string Password { get; private set; }
            ///
            public bool? Reset { get; private set; }

            ///
            public Builder(string flowID, string password)
            {
                this.FlowID = flowID;
                this.Password = password;
            }

            ///
            public Builder WithReset(bool? reset)
            {
                this.Reset = reset;
                return this;
            }

            ///
            public FlowVerifyPasswordRequest Build()
            {
                return new FlowVerifyPasswordRequest(this);
            }
        }
    }
}

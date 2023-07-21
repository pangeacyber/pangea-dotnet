using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class FlowVerifyMFACompleteRequest : BaseRequest
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; }

        ///
        [JsonProperty("code")]
        public string Code { get; private set; }

        ///
        [JsonProperty("cancel")]
        public bool? Cancel { get; private set; }

        private FlowVerifyMFACompleteRequest(Builder builder)
        {
            this.FlowID = builder.FlowID;
            this.Code = builder.Code;
            this.Cancel = builder.Cancel;
        }

        ///
        public class Builder
        {
            ///
            public string FlowID { get; private set; }
            ///
            public string Code { get; private set; }
            ///
            public bool? Cancel { get; private set; }

            ///
            public Builder(string flowID, string code)
            {
                this.FlowID = flowID;
                this.Code = code;
            }

            ///
            public Builder WithCancel(bool? cancel)
            {
                this.Cancel = cancel;
                return this;
            }

            ///
            public FlowVerifyMFACompleteRequest Build()
            {
                return new FlowVerifyMFACompleteRequest(this);
            }
        }
    }
}

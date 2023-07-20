using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class FlowEnrollMFAStartRequest : BaseRequest
    {
        ///
        [JsonProperty("flow_id")]
        public string FlowID { get; private set; }

        ///
        [JsonProperty("mfa_provider")]
        public MFAProvider MfaProvider { get; private set; }

        ///
        [JsonProperty("phone")]
        public string Phone { get; private set; }

        private FlowEnrollMFAStartRequest(Builder builder)
        {
            this.FlowID = builder.FlowID;
            this.MfaProvider = builder.MFAProvider;
            this.Phone = builder.Phone;
        }

        ///
        public class Builder
        {
            ///
            public string FlowID { get; private set; }
            ///
            public MFAProvider MFAProvider { get; private set; }
            ///
            public string? Phone { get; private set; }

            ///
            public Builder(string flowID, MFAProvider mfaProvider)
            {
                this.FlowID = flowID;
                this.MFAProvider = mfaProvider;
            }

            ///
            public FlowEnrollMFAStartRequest Build()
            {
                return new FlowEnrollMFAStartRequest(this);
            }

            ///
            public Builder WithPhone(string phone)
            {
                this.Phone = phone;
                return this;
            }
        }
    }
}

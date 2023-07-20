using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPReputationRequest : IntelCommonRequest<IPReputationRequest.Builder>
    {
        ///
        [JsonProperty("ip")]
        public string IP { get; set; }

        ///
        protected IPReputationRequest(Builder builder)
            : base(builder)
        {
            IP = builder.IP;
        }

        ///
        public class Builder : IntelCommonRequest<IPReputationRequest.Builder>.CommonBuilder
        {
            ///
            public string IP { get; private set; }

            ///
            public Builder(string ip)
            {
                IP = ip;
            }

            ///
            public new IPReputationRequest Build()
            {
                return new IPReputationRequest(this);
            }
        }
    }
}

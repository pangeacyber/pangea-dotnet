using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPDomainRequest : IntelCommonRequest<IPDomainRequest.Builder>
    {
        ///
        [JsonProperty("ip")]
        public string IP { get; set; }

        ///
        protected IPDomainRequest(Builder builder)
            : base(builder)
        {
            IP = builder.IP;
        }

        ///
        public class Builder : IntelCommonRequest<IPDomainRequest.Builder>.CommonBuilder
        {
            ///
            public string IP { get; private set; }

            ///
            public Builder(string ip)
            {
                IP = ip;
            }

            ///
            public new IPDomainRequest Build()
            {
                return new IPDomainRequest(this);
            }
        }
    }
}

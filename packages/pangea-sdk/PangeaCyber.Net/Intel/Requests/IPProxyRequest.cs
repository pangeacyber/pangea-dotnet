using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPProxyRequest : IntelCommonRequest<IPProxyRequest.Builder>
    {
        ///
        [JsonProperty("ip")]
        public string IP { get; set; }

        ///
        protected IPProxyRequest(Builder builder)
            : base(builder)
        {
            IP = builder.IP;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string IP { get; private set; }

            ///
            public Builder(string ip)
            {
                IP = ip;
            }

            ///
            public new IPProxyRequest Build()
            {
                return new IPProxyRequest(this);
            }
        }
    }
}

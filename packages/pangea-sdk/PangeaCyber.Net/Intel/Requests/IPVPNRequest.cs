using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPVPNRequest : IntelCommonRequest<IPVPNRequest.Builder>
    {
        ///
        [JsonProperty("ip")]
        public string IP { get; set; }

        ///
        protected IPVPNRequest(Builder builder)
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
            public new IPVPNRequest Build()
            {
                return new IPVPNRequest(this);
            }
        }
    }
}

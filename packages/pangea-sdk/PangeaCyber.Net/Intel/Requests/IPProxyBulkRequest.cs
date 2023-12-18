using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPProxyBulkRequest : IntelCommonRequest<IPProxyBulkRequest.Builder>
    {
        ///
        [JsonProperty("ips")]
        public string[] IPs { get; set; }

        ///
        protected IPProxyBulkRequest(Builder builder)
            : base(builder)
        {
            IPs = builder.IPs;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string[] IPs { get; private set; }

            ///
            public Builder(string[] ips)
            {
                IPs = ips;
            }

            ///
            public new IPProxyBulkRequest Build()
            {
                return new IPProxyBulkRequest(this);
            }
        }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPDomainBulkRequest : IntelCommonRequest<IPDomainBulkRequest.Builder>
    {
        ///
        [JsonProperty("ips")]
        public string[] IPs { get; set; }

        ///
        protected IPDomainBulkRequest(Builder builder)
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
            public new IPDomainBulkRequest Build()
            {
                return new IPDomainBulkRequest(this);
            }
        }
    }
}

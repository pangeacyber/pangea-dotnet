using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPReputationBulkRequest : IntelCommonRequest<IPReputationBulkRequest.Builder>
    {
        ///
        [JsonProperty("ips")]
        public string[] IPs { get; set; }

        ///
        protected IPReputationBulkRequest(Builder builder)
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
            public new IPReputationBulkRequest Build()
            {
                return new IPReputationBulkRequest(this);
            }
        }
    }
}

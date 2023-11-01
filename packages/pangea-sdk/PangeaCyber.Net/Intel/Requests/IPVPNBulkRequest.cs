using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPVPNBulkRequest : IntelCommonRequest<IPVPNBulkRequest.Builder>
    {
        ///
        [JsonProperty("ips")]
        public string[] IPs { get; set; }

        ///
        protected IPVPNBulkRequest(Builder builder)
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
            public new IPVPNBulkRequest Build()
            {
                return new IPVPNBulkRequest(this);
            }
        }
    }
}

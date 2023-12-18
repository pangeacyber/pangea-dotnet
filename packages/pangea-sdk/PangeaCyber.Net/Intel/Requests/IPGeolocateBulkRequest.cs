using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPGeolocateBulkRequest : IntelCommonRequest<IPGeolocateBulkRequest.Builder>
    {
        ///
        [JsonProperty("ips")]
        public string[] IPs { get; set; }

        ///
        protected IPGeolocateBulkRequest(Builder builder)
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
            public new IPGeolocateBulkRequest Build()
            {
                return new IPGeolocateBulkRequest(this);
            }
        }
    }
}

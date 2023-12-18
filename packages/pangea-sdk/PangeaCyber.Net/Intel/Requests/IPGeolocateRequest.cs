using Newtonsoft.Json;

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPGeolocateRequest : IntelCommonRequest<IPGeolocateRequest.Builder>
    {
        ///
        [JsonProperty("ip")]
        public string IP { get; set; }

        ///
        protected IPGeolocateRequest(Builder builder)
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
            public new IPGeolocateRequest Build()
            {
                return new IPGeolocateRequest(this);
            }
        }
    }
}

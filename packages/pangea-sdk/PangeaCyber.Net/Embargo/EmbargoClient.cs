namespace PangeaCyber.Net.Embargo
{
    ///
    public class EmbargoClient : Client
    {
        private const string ServiceName = "embargo";
        private static readonly bool SupportMultiConfig = false;

        ///
        public EmbargoClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : Client.ClientBuilder
        {
            ///
            public Builder(Config config)
                : base(config)
            {
            }

            ///
            public EmbargoClient Build()
            {
                return new EmbargoClient(this);
            }
        }

        ///
        public Task<Response<EmbargoSanctions>> ISOCheck(string isoCode)
        {
            var request = new ISOCheckRequest(isoCode);
            return DoPost<EmbargoSanctions>("/v1/iso/check", request);
        }

        ///
        public Task<Response<EmbargoSanctions>> IPCheck(string ip)
        {
            var request = new IPCheckRequest(ip);
            return DoPost<EmbargoSanctions>("/v1/ip/check", request);
        }
    }
}

namespace PangeaCyber.Net.Intel
{
    ///
    public class IPIntelClient : BaseClient
    {
        private const string ServiceName = "ip-intel";
        private static readonly bool SupportMultiConfig = false;

        ///
        public IPIntelClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient.ClientBuilder
        {
            ///
            public Builder(Config config)
                : base(config)
            {
            }

            ///
            public IPIntelClient Build()
            {
                return new IPIntelClient(this);
            }
        }

        ///
        public Task<Response<IPGeolocateResult>> Geolocate(IPGeolocateRequest request)
        {
            return DoPost<IPGeolocateResult>("/v1/geolocate", request);
        }

        ///
        public Task<Response<IPDomainResult>> GetDomain(IPDomainRequest request)
        {
            return DoPost<IPDomainResult>("/v1/domain", request);
        }

        ///
        public Task<Response<IPVPNResult>> IsVPN(IPVPNRequest request)
        {
            return DoPost<IPVPNResult>("/v1/vpn", request);
        }

        ///
        public Task<Response<IPProxyResult>> IsProxy(IPProxyRequest request)
        {
            return DoPost<IPProxyResult>("/v1/proxy", request);
        }

        ///
        public Task<Response<IPReputationResult>> Reputation(IPReputationRequest request)
        {
            return DoPost<IPReputationResult>("/v1/reputation", request);
        }
    }
}

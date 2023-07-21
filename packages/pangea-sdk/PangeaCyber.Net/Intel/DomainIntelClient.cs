namespace PangeaCyber.Net.Intel
{
    ///
    public class DomainIntelClient : BaseClient<DomainIntelClient.Builder>
    {
        private const string ServiceName = "domain-intel";
        private static readonly bool SupportMultiConfig = false;

        ///
        public DomainIntelClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient<DomainIntelClient.Builder>.ClientBuilder
        {
            ///
            public Builder(Config config)
                : base(config)
            {
            }

            ///
            public DomainIntelClient Build()
            {
                return new DomainIntelClient(this);
            }
        }

        ///
        public Task<Response<DomainReputationResult>> Reputation(DomainReputationRequest request)
        {
            return DoPost<DomainReputationResult>("/v1/reputation", request);
        }
    }
}

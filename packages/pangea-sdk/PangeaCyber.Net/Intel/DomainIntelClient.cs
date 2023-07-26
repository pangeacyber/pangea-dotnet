namespace PangeaCyber.Net.Intel
{
    /// <kind>class</kind>
    /// <summary>
    /// DomainIntel Client
    /// </summary>
    public class DomainIntelClient : BaseClient<DomainIntelClient.Builder>
    {
        private const string ServiceName = "domain-intel";
        private static readonly bool SupportMultiConfig = false;

        /// Constructor
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

        /// <kind>method</kind>
        /// <summary>Retrieve reputation for a domain from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation</remarks>
        /// <operationid>domain_intel_post_v1_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.DomainReputationRequest">DomainReputationRequest with a domain and provider</param>
        /// <returns>Response&lt;DomainReputationResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new DomainReputationRequest.Builder("737updatesboeing.com").Build();
        /// var response = await client.Reputation(request);
        /// </code>
        /// </example>
        public Task<Response<DomainReputationResult>> Reputation(DomainReputationRequest request)
        {
            return DoPost<DomainReputationResult>("/v1/reputation", request);
        }
    }
}

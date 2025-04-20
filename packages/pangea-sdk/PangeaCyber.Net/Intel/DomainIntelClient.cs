namespace PangeaCyber.Net.Intel
{
    /// <summary>Domain Intel client.</summary>
    /// <remarks>Domain Intel</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token");
    /// var builder = new DomainIntelClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class DomainIntelClient : BaseClient<DomainIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "domain-intel";

        /// <summary>Create a new <see cref="DomainIntelClient"/> using the given builder.</summary>
        public DomainIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="DomainIntelClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="DomainIntelClient"/> builder.</summary>
            public Builder(Config config)
                : base(config)
            {
            }

            /// <summary>Build a <see cref="DomainIntelClient"/>.</summary>
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

        /// <kind>method</kind>
        /// <summary>Retrieve reputations for a list of domains, from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation V2</remarks>
        /// <operationid>domain_intel_post_v2_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.DomainReputationBulkRequest">DomainReputationBulkRequest with a domain list and provider</param>
        /// <returns>Response&lt;DomainReputationBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] domains = new string[1] {"737updatesboeing.com"};
        /// var request = new DomainReputationBulkRequest.Builder(domains).Build();
        /// var response = await client.ReputationBulk(request);
        /// </code>
        /// </example>
        public Task<Response<DomainReputationBulkResult>> ReputationBulk(DomainReputationBulkRequest request)
        {
            return DoPost<DomainReputationBulkResult>("/v2/reputation", request);
        }

        /// <kind>method</kind>
        /// <summary>Retrieve who is for a domain from a provider, including an optional detailed report.</summary>
        /// <remarks>WhoIs</remarks>
        /// <operationid>domain_intel_post_v1_whois</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.DomainWhoIsRequest">DomainWhoIsRequest with a domain and provider</param>
        /// <returns>Response&lt;DomainWhoIsResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new DomainWhoIsResult.Builder("google.com").Build();
        /// var response = await client.WhoIs(request);
        /// </code>
        /// </example>
        public Task<Response<DomainWhoIsResult>> WhoIs(DomainWhoIsRequest request)
        {
            return DoPost<DomainWhoIsResult>("/v1/whois", request);
        }
    }
}

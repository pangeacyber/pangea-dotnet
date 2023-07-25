namespace PangeaCyber.Net.Intel
{
    /// <kind>class</kind>
    /// <summary>
    /// URLIntel Client
    /// </summary>
    public class URLIntelClient : BaseClient<URLIntelClient.Builder>
    {
        private const string ServiceName = "url-intel";
        private static readonly bool SupportMultiConfig = false;

        /// Constructor
        public URLIntelClient(Builder builder)
            : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient<URLIntelClient.Builder>.ClientBuilder
        {
            ///
            public Builder(Config config)
                : base(config)
            {
            }

            ///
            public URLIntelClient Build()
            {
                return new URLIntelClient(this);
            }
        }

        /// <kind>method</kind>
        /// <summary>Retrieve a reputation score for a URL from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation</remarks>
        /// <operationid>url_intel_post_v1_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.URLReputationRequest">URLReputationRequest with the URL to be looked up</param>
        /// <returns>Response&lt;URLReputationResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new URLReputationRequest.Builder(
        ///     "http://113.235.101.11:54384")
        ///     .Build();
        /// var response = await client.Reputation(request);
        /// </code>
        /// </example>
        public async Task<Response<URLReputationResult>> Reputation(URLReputationRequest request)
        {
            return await this.DoPost<URLReputationResult>("/v1/reputation", request);
        }
    }
}

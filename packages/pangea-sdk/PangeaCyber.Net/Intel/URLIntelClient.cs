namespace PangeaCyber.Net.Intel
{
    /// <summary>URL Intel client.</summary>
    /// <remarks>URL Intel</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token");
    /// var builder = new URLIntelClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class URLIntelClient : BaseClient<URLIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "url-intel";

        /// <summary>Create a new <see cref="URLIntelClient"/> using the given builder.</summary>
        public URLIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="URLIntelClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="URLIntelClient"/> builder.</summary>
            public Builder(Config config)
                : base(config)
            {
            }

            /// <summary>Build an <see cref="URLIntelClient"/>.</summary>
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

        /// <kind>method</kind>
        /// <summary>Retrieve reputation scores for a list of URLs, from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation V2</remarks>
        /// <operationid>url_intel_post_v2_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.URLReputationBulkRequest">URLReputationBulkRequest with the URL list to be looked up</param>
        /// <returns>Response&lt;URLReputationBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] urls = new string[1] {"http://113.235.101.11:54384"};
        /// var request = new URLReputationBulkRequest.Builder(urls).Build();
        /// var response = await client.ReputationBulk(request);
        /// </code>
        /// </example>
        public async Task<Response<URLReputationBulkResult>> ReputationBulk(URLReputationBulkRequest request)
        {
            return await this.DoPost<URLReputationBulkResult>("/v2/reputation", request);
        }
    }
}

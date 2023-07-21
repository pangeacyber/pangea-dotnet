namespace PangeaCyber.Net.Intel
{
    ///
    public class URLIntelClient : BaseClient
    {
        private const string ServiceName = "url-intel";
        private static readonly bool SupportMultiConfig = false;

        ///
        public URLIntelClient(Builder builder)
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
            public URLIntelClient Build()
            {
                return new URLIntelClient(this);
            }
        }

        ///
        public async Task<Response<URLReputationResult>> Reputation(URLReputationRequest request)
        {
            return await this.DoPost<URLReputationResult>("/v1/reputation", request);
        }
    }
}

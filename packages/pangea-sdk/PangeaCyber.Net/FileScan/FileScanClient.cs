namespace PangeaCyber.Net.FileScan
{
    /// <kind>class</kind>
    /// <summary>
    /// FileScan Client
    /// </summary>
    public class FileScanClient : BaseClient<FileScanClient.Builder>
    {
        ///
        public static string ServiceName = "file-scan";
        private static readonly bool SupportMultiConfig = false;

        ///
        public FileScanClient(Builder builder) : base(builder, ServiceName, SupportMultiConfig)
        {
        }

        ///
        public class Builder : BaseClient<FileScanClient.Builder>.ClientBuilder
        {
            ///
            public Builder(Config config) : base(config)
            {
            }

            ///
            public FileScanClient Build()
            {
                return new FileScanClient(this);
            }
        }

        /// <kind>method</kind>
        /// <summary>Retrieve a reputation score for an IP address from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation</remarks>
        /// <operationid>ip_intel_post_v1_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPReputationRequest">IPReputationRequest with the ip to be looked up</param>
        /// <returns>Response&lt;IPReputationResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new IPReputationRequest.Builder(
        ///     "93.231.182.110")
        ///     .WithProvider("crowdstrike")
        ///     .WithVerbose(true)
        ///     .WithRaw(true)
        ///     .Build();
        /// var response = await client.Reputation(request);
        /// </code>
        /// </example>
        public async Task<Response<FileScanResult>> Scan(FileScanRequest request, FileStream file)
        {
            return await DoPost<FileScanResult>("/v1/scan", request, file);
        }
    }
}

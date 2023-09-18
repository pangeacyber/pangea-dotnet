namespace PangeaCyber.Net.Intel
{
    /// <kind>class</kind>
    /// <summary>
    /// IPIntel Client
    /// </summary>
    public class IPIntelClient : BaseClient<IPIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "ip-intel";

        /// Constructor
        public IPIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        ///
        public class Builder : BaseClient<IPIntelClient.Builder>.ClientBuilder
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

        /// <kind>method</kind>
        /// <summary>Retrieve location information associated with an IP address.</summary>
        /// <remarks>Geolocate</remarks>
        /// <operationid>ip_intel_post_v1_geolocate</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPGeolocateRequest">IPGeolocateRequest with the ip to be looked up</param>
        /// <returns>Response&lt;IPGeolocateResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new IPGeolocateRequest.Builder(
        ///     "93.231.182.110")
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.Geolocate(request);
        /// </code>
        /// </example>
        public Task<Response<IPGeolocateResult>> Geolocate(IPGeolocateRequest request)
        {
            return DoPost<IPGeolocateResult>("/v1/geolocate", request);
        }

        /// <kind>method</kind>
        /// <summary>Retrieve the domain name associated with an IP address.</summary>
        /// <remarks>Domain</remarks>
        /// <operationid>ip_intel_post_v1_domain</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPDomainRequest">IPDomainRequest with the ip to be looked up</param>
        /// <returns>Response&lt;IPDomainResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new IPDomainRequest.Builder(
        ///     "24.235.114.61")
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.GetDomain(request);
        /// </code>
        /// </example>
        public Task<Response<IPDomainResult>> GetDomain(IPDomainRequest request)
        {
            return DoPost<IPDomainResult>("/v1/domain", request);
        }

        /// <kind>method</kind>
        /// <summary>Determine if an IP address originates from a VPN.</summary>
        /// <remarks>VPN</remarks>
        /// <operationid>ip_intel_post_v1_vpn</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPVPNRequest">IPVPNRequest with the ip to be looked up</param>
        /// <returns>Response&lt;IPVPNResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new IPVPNRequest.Builder(
        ///     "2.56.189.74")
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.IsVPN(request);
        /// </code>
        /// </example>
        public Task<Response<IPVPNResult>> IsVPN(IPVPNRequest request)
        {
            return DoPost<IPVPNResult>("/v1/vpn", request);
        }

        /// <kind>method</kind>
        /// <summary>Determine if an IP address originates from a proxy.</summary>
        /// <remarks>Proxy</remarks>
        /// <operationid>ip_intel_post_v1_proxy</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPProxyRequest">IPProxyRequest with the ip to be looked up</param>
        /// <returns>Response&lt;IPProxyResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new IPProxyRequest.Builder(
        ///     "34.201.32.172")
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.IsProxy(request);
        /// </code>
        /// </example>
        public Task<Response<IPProxyResult>> IsProxy(IPProxyRequest request)
        {
            return DoPost<IPProxyResult>("/v1/proxy", request);
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
        public Task<Response<IPReputationResult>> Reputation(IPReputationRequest request)
        {
            return DoPost<IPReputationResult>("/v1/reputation", request);
        }
    }
}

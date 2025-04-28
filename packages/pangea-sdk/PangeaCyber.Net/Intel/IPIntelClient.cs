namespace PangeaCyber.Net.Intel
{
    /// <summary>IP Intel client.</summary>
    /// <remarks>IP Intel</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token");
    /// var builder = new IPIntelClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class IPIntelClient : BaseClient<IPIntelClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "ip-intel";

        /// <summary>Create a new <see cref="IPIntelClient"/> using the given builder.</summary>
        public IPIntelClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="IPIntelClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="IPIntelClient"/> builder.</summary>
            public Builder(Config config)
                : base(config)
            {
            }

            /// <summary>Build an <see cref="IPIntelClient"/>.</summary>
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
        /// <summary>Retrieve location information associated with a list of IP addresses.</summary>
        /// <remarks>Geolocate V2</remarks>
        /// <operationid>ip_intel_post_v2_geolocate</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPGeolocateBulkRequest">IPGeolocateBulkRequest with the ips to be looked up</param>
        /// <returns>Response&lt;IPGeolocateBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] ips = new string[1] {"93.231.182.110"};
        /// var request = new IPGeolocateBulkRequest.Builder(ips)
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.GeolocateBulk(request);
        /// </code>
        /// </example>
        public Task<Response<IPGeolocateBulkResult>> GeolocateBulk(IPGeolocateBulkRequest request)
        {
            return DoPost<IPGeolocateBulkResult>("/v2/geolocate", request);
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
        /// <summary>Retrieve the domain names associated with a list of IP addresses.</summary>
        /// <remarks>Domain V2</remarks>
        /// <operationid>ip_intel_post_v2_domain</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPDomainBulkRequest">IPDomainBulkRequest with the ips to be looked up</param>
        /// <returns>Response&lt;IPDomainBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] ips = new string[1] {"24.235.114.61"};
        /// var request = new IPDomainBulkRequest.Builder(ips)
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.GetDomainBulk(request);
        /// </code>
        /// </example>
        public Task<Response<IPDomainBulkResult>> GetDomainBulk(IPDomainBulkRequest request)
        {
            return DoPost<IPDomainBulkResult>("/v2/domain", request);
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
        /// <summary>Determine which IP addresses originate from a VPN.</summary>
        /// <remarks>VPN V2</remarks>
        /// <operationid>ip_intel_post_v2_vpn</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPVPNBulkRequest">IPVPNBulkRequest with the ips to be looked up</param>
        /// <returns>Response&lt;IPVPNBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] ips = new string[1] {"2.56.189.74"};
        /// var request = new IPVPNBulkRequest.Builder(ips)
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.IsVPNBulk(request);
        /// </code>
        /// </example>
        public Task<Response<IPVPNBulkResult>> IsVPNBulk(IPVPNBulkRequest request)
        {
            return DoPost<IPVPNBulkResult>("/v2/vpn", request);
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
        /// <summary>Determine which IP addresses originate from a proxy.</summary>
        /// <remarks>Proxy V2</remarks>
        /// <operationid>ip_intel_post_v2_proxy</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPProxyBulkRequest">IPProxyBulkRequest with the ip to be looked up</param>
        /// <returns>Response&lt;IPProxyBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] ips = new string[1] {"34.201.32.172"};
        /// var request = new IPProxyBulkRequest.Builder(ips)
        ///     .WithProvider("digitalelement")
        ///     .WithVerbose(false)
        ///     .WithRaw(false)
        ///     .Build();
        /// var response = await client.IsProxyBulk(request);
        /// </code>
        /// </example>
        public Task<Response<IPProxyBulkResult>> IsProxyBulk(IPProxyBulkRequest request)
        {
            return DoPost<IPProxyBulkResult>("/v2/proxy", request);
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

        /// <kind>method</kind>
        /// <summary>Retrieve reputation scores for a list of IP addresses, from a provider, including an optional detailed report.</summary>
        /// <remarks>Reputation V2</remarks>
        /// <operationid>ip_intel_post_v2_reputation</operationid>
        /// <param name="request" type="PangeaCyber.Net.Intel.IPReputationBulkRequest">IPReputationBulkRequest with the ip list to be looked up</param>
        /// <returns>Response&lt;IPReputationBulkResult&gt;</returns>
        /// <example>
        /// <code>
        /// string[] ips = new string[1] {"93.231.182.110"};
        /// var request = new IPReputationBulkResult.Builder(ips)
        ///     .WithProvider("crowdstrike")
        ///     .WithVerbose(true)
        ///     .WithRaw(true)
        ///     .Build();
        /// var response = await client.ReputationBulk(request);
        /// </code>
        /// </example>
        public Task<Response<IPReputationBulkResult>> ReputationBulk(IPReputationBulkRequest request)
        {
            return DoPost<IPReputationBulkResult>("/v2/reputation", request);
        }
    }
}

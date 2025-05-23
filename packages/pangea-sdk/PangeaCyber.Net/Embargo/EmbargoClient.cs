namespace PangeaCyber.Net.Embargo
{
    /// <summary>Embargo client.</summary>
    /// <remarks>Embargo</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token");
    /// var builder = new EmbargoClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class EmbargoClient : BaseClient<EmbargoClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "embargo";

        /// <summary>Create a new <see cref="EmbargoClient"/> using the given builder.</summary>
        public EmbargoClient(Builder builder)
            : base(builder, ServiceName)
        {
        }

        /// <summary><see cref="EmbargoClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Create a new <see cref="EmbargoClient"/> builder.</summary>
            public Builder(Config config)
                : base(config)
            {
            }

            /// <summary>Build an <see cref="EmbargoClient"/>.</summary>
            public EmbargoClient Build()
            {
                return new EmbargoClient(this);
            }
        }

        /// <kind>method</kind>
        /// <summary>Check country codes against known sanction and trade embargo lists.</summary>
        /// <remarks>ISO Code Check</remarks>
        /// <operationid>embargo_post_v1_iso_check</operationid>
        /// <param name="isoCode" type="string">Check this two character country ISO code against the enabled embargo lists.</param>
        /// <returns>Response&lt;EmbargoSanctions&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.ISOCheck("CU");
        /// </code>
        /// </example>
        public Task<Response<EmbargoSanctions>> ISOCheck(string isoCode)
        {
            var request = new ISOCheckRequest(isoCode);
            return DoPost<EmbargoSanctions>("/v1/iso/check", request);
        }

        /// <kind>method</kind>
        /// <summary>Check IPs against known sanction and trade embargo lists.</summary>
        /// <remarks>Check IP</remarks>
        /// <operationid>embargo_post_v1_ip_check</operationid>
        /// <param name="ip" type="string">Geolocate this IP and check the corresponding country against the enabled embargo lists.</param>
        /// <returns>Response&lt;EmbargoSanctions&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.IPCheck("190.6.64.94");
        /// </code>
        /// </example>
        public Task<Response<EmbargoSanctions>> IPCheck(string ip)
        {
            var request = new IPCheckRequest(ip);
            return DoPost<EmbargoSanctions>("/v1/ip/check", request);
        }
    }
}

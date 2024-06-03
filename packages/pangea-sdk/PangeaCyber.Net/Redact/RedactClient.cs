using PangeaCyber.Net.Exceptions;

namespace PangeaCyber.Net.Redact
{
    /// <summary>Redact client.</summary>
    /// <remarks>Redact</remarks>
    /// <example>
    /// <code>
    /// var config = new Config("pangea_token", "pangea_domain");
    /// var builder = new RedactClient.Builder(config);
    /// var client = builder.Build();
    /// </code>
    /// </example>
    public class RedactClient : BaseClient<RedactClient.Builder>
    {
        ///
        public static string ServiceName { get; } = "redact";

        /// <summary>Create a new <see cref="RedactClient"/> using the given builder.</summary>
        public RedactClient(Builder builder) : base(builder, ServiceName)
        {
            ConfigID = builder.ConfigID ?? ConfigID;
        }

        private async Task<Response<RedactTextResult>> redactPost(RedactTextRequest request)
        {
            return await DoPost<RedactTextResult>("/v1/redact", request);
        }

        private async Task<Response<RedactStructuredResult>> structuredPost(RedactStructuredRequest request)
        {
            return await DoPost<RedactStructuredResult>("/v1/redact_structured", request);
        }

        /// <kind>method</kind>
        /// <summary>Redact sensitive information from provided text.</summary>
        /// <remarks>Redact</remarks>
        /// <operationid>redact_post_v1_redact</operationid>
        /// <param name="request" type="PangeaCyber.Net.Redact.RedactTextRequest">RedactRequest with text and optional parameters</param>
        /// <returns>Response&lt;RedactTextResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var request = new RedactTextRequest.RequestTextBuilder("Jenny Jenny... 415-867-5309").Build();
        /// var response = await client.RedactText(request);
        /// </code>
        /// </example>
        public async Task<Response<RedactTextResult>> RedactText(RedactTextRequest request)
        {
            return await this.redactPost(request);
        }

        /// <kind>method</kind>
        /// <summary>Redact sensitive information from structured data (e.g., JSON).</summary>
        /// <remarks>Redact structured</remarks>
        /// <operationid>redact_post_v1_redact_structured</operationid>
        /// <param name="request" type="PangeaCyber.Net.Redact.RedactTextRequest">RedactRequest with structured data</param>
        /// <returns>Response&lt;RedactStructuredResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        /// <example>
        /// <code>
        /// var request = new RedactStructuredRequest.RequestStructureBuilder("Jenny Jenny... 415-867-5309").Build();
        /// var response = await client.RedactStructured(request);
        /// </code>
        /// </example>
        public async Task<Response<RedactStructuredResult>> RedactStructured(RedactStructuredRequest request)
        {
            return await this.structuredPost(request);
        }

        /// <kind>method</kind>
        /// <summary>Decrypt or unredact fpe redactions.</summary>
        /// <remarks>Unredact</remarks>
        /// <operationid>redact_post_v1_unredact</operationid>
        /// <param name="request">UnredactRequest with redacted data</param>
        /// <returns>Response&lt;UnredactResult&gt;</returns>
        /// <exception cref="PangeaException"></exception>
        /// <exception cref="PangeaAPIException"></exception>
        public async Task<Response<UnredactResult>> Unredact(UnredactRequest request)
        {
            return await DoPost<UnredactResult>("/v1/unredact", request);
        }

        /// <summary><see cref="RedactClient"/> builder.</summary>
        public class Builder : ClientBuilder
        {
            /// <summary>Config ID.</summary>
            public string? ConfigID;

            /// <summary>Create a new <see cref="RedactClient"/> builder.</summary>
            public Builder(Config config) : base(config)
            {
            }

            /// <summary>Build a <see cref="RedactClient"/>.</summary>
            public RedactClient Build()
            {
                return new RedactClient(this);
            }

            /// <summary>Add config ID.</summary>
            public Builder WithConfigID(string configID)
            {
                ConfigID = configID;
                return this;
            }
        }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class ClientToken : AuthNBaseClient
    {
        ///
        public ClientToken(AuthNClient.Builder builder) : base(builder)
        {
        }

        /// <kind>method</kind>
        /// <summary>Look up a token and return its contents.</summary>
        /// <remarks>Check a token</remarks>
        /// <operationid>authn_post_v2_client_token_check</operationid>
        /// <param name="token" type="string">A token value</param>
        /// <returns>Response&lt;ClientTokenCheckResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.Client.Token.Check("ptu_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a");
        /// </code>
        /// </example>
        public async Task<Response<ClientTokenCheckResult>> Check(string token)
        {
            TokenCheckRequest request = new TokenCheckRequest(token);
            return await DoPost<ClientTokenCheckResult>("/v2/client/token/check", request);
        }

        internal class TokenCheckRequest : BaseRequest
        {
            [JsonProperty("token")]
            public string Token { get; private set; }

            public TokenCheckRequest(string token)
            {
                Token = token;
            }
        }
    }
}

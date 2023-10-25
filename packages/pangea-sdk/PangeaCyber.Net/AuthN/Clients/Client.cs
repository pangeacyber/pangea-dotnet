using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class Client : AuthNBaseClient
    {
        ///
        public ClientSession Session { get; private set; }
        ///
        public ClientPassword Password { get; private set; }
        ///
        public ClientToken Token { get; private set; }

        ///
        public Client(AuthNClient.Builder builder) : base(builder)
        {
            Session = new ClientSession(builder);
            Password = new ClientPassword(builder);
            Token = new ClientToken(builder);
        }

        /// <kind>method</kind>
        /// <summary>Retrieve the logged in user's token and information.</summary>
        /// <remarks>Get User (client token)</remarks>
        /// <operationid>authn_post_v2_client_userinfo</operationid>
        /// <param name="code" type="string">Login code returned by the login callback</param>
        /// <returns>Response&lt;ClientUserinfoResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<ClientUserinfoResult>> Userinfo(string code)
        {
            UserinfoRequest request = new UserinfoRequest(code);
            return await DoPost<ClientUserinfoResult>("/v2/client/userinfo", request);
        }

        /// <kind>method</kind>
        /// <summary>Get JWT verification keys.</summary>
        /// <remarks>Get JWT verification keys</remarks>
        /// <operationid>authn_post_v2_client_jwks</operationid>
        /// <returns>Response&lt;ClientJWKSResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<ClientJWKSResult>> Jwks()
        {
            return await DoPost<ClientJWKSResult>("/v2/client/jwks", new BaseRequest());
        }

        internal class UserinfoRequest : BaseRequest
        {
            [JsonProperty("code")]
            public string Code { get; private set; }

            public UserinfoRequest(string code)
            {
                Code = code;
            }
        }
    }
}

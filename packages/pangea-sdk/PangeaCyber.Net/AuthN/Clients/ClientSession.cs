using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class ClientSession : AuthNBaseClient
    {
        ///
        public ClientSession(AuthNClient.Builder builder) : base(builder)
        {
        }

        /// <kind>method</kind>
        /// <summary>Invalidate a session by session ID using a client token.</summary>
        /// <remarks>Invalidate Session | Client</remarks>
        /// <operationid>authn_post_v2_client_password_change</operationid>
        /// <param name="token" type="string">A user token value</param>
        /// <param name="sessionID" type="string">An ID for a token</param>
        /// <returns>Response&lt;ClientSessionInvalidateResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.ClientSession.Invalidate(
        ///     "ptu_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a", 
        ///     "pmt_zppkzrjguxyblaia6itbiesejn7jejnr"
        /// );
        /// </code>
        /// </example>
        public async Task<Response<ClientSessionInvalidateResult>> Invalidate(string token, string sessionID)
        {
            var request = new ClientSessionInvalidateRequest(token, sessionID);
            return await DoPost<ClientSessionInvalidateResult>("/v2/client/session/invalidate", request);
        }

        /// <kind>method</kind>
        /// <summary>List sessions using a client token.</summary>
        /// <remarks>List sessions (client token)</remarks>
        /// <operationid>authn_post_v2_client_session_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.ClientSessionListRequest">ClientSessionListRequest</param>
        /// <returns>Response&lt;ClientSessionListResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new ClientSessionListRequest.Builder().Build();
        /// 
        /// var response = await client.ClientSession.List(request);
        /// </code>
        /// </example>
        public async Task<Response<ClientSessionListResult>> List(ClientSessionListRequest request)
        {
            return await DoPost<ClientSessionListResult>("/v2/client/session/list", request);
        }

        /// <kind>method</kind>
        /// <summary>Log out the current user's session.</summary>
        /// <remarks>Log out (client token)</remarks>
        /// <operationid>authn_post_v2_client_session_logout</operationid>
        /// <param name="token" type="string">A user token value</param>
        /// <returns>Response&lt;ClientSessionLogoutResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.ClientSession.Logout("ptu_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a");
        /// </code>
        /// </example>
        public async Task<Response<ClientSessionLogoutResult>> Logout(string token)
        {
            var request = new ClientSessionLogoutRequest(token);
            return await DoPost<ClientSessionLogoutResult>("/v2/client/session/logout", request);
        }

        /// <kind>method</kind>
        /// <summary>Refresh a session token.</summary>
        /// <remarks>Refresh a Session</remarks>
        /// <operationid>authn_post_v2_client_session_refresh</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.ClientSessionRefreshRequest">ClientSessionRefreshRequest</param>
        /// <returns>Response&lt;ClientSessionRefreshResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new ClientSessionRefreshRequest.Builder(
        ///     "ptr_xpkhwpnz2cmegsws737xbsqnmnuwtbm5")
        /// .WithUserToken("ptu_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a")
        /// .Build();
        /// 
        /// var response = await client.ClientSession.Refresh(request);
        /// </code>
        /// </example>
        public async Task<Response<ClientSessionRefreshResult>> Refresh(ClientSessionRefreshRequest request)
        {
            return await DoPost<ClientSessionRefreshResult>("/v2/client/session/refresh", request);
        }

        internal class ClientSessionInvalidateRequest : BaseRequest
        {
            [JsonProperty("token")]
            public string Token { get; private set; }

            [JsonProperty("session_id")]
            public string SessionID { get; private set; }

            public ClientSessionInvalidateRequest(string token, string sessionID)
            {
                Token = token;
                SessionID = sessionID;
            }
        }

        internal class ClientSessionLogoutRequest : BaseRequest
        {
            [JsonProperty("token")]
            public string Token { get; private set; }

            public ClientSessionLogoutRequest(string token)
            {
                Token = token;
            }
        }
    }
}

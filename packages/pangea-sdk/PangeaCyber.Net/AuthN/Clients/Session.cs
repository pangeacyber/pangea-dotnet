using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{

    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class Session : AuthNBaseClient
    {
        ///
        public Session(AuthNClient.Builder builder) : base(builder) { }

        /// <kind>method</kind>
        /// <summary>Invalidate a session by session ID.</summary>
        /// <remarks>Invalidate Session</remarks>
        /// <operationid>authn_post_v2_session_invalidate</operationid>
        /// <param name="sessionID" type="string">An ID for a token</param>
        /// <returns>Response&lt;SessionInvalidateResult&gt;</returns>
        /// <example>
        /// <code>
        /// await client.Session.Invalidate("pmt_zppkzrjguxyblaia6itbiesejn7jejnr");
        /// </code>
        /// </example>
        public async Task<Response<SessionInvalidateResult>> Invalidate(string sessionID)
        {
            var request = new SessionInvalidateRequest(sessionID);
            return await DoPost<SessionInvalidateResult>("/v2/session/invalidate", request);
        }

        /// <kind>method</kind>
        /// <summary>List sessions.</summary>
        /// <remarks>List session (service token)</remarks>
        /// <operationid>authn_post_v2_session_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.SessionListRequest"></param>
        /// <returns>Response&lt;SessionListResult&gt;</returns>
        /// <example>
        /// <code>
        /// var request = new SessionListRequest.Builder().Build();
        /// 
        /// var response = await client.Session.List(request);
        /// </code>
        /// </example>
        public async Task<Response<SessionListResult>> List(SessionListRequest request)
        {
            return await DoPost<SessionListResult>("/v2/session/list", request);
        }

        /// <kind>method</kind>
        /// <summary>Invalidate all sessions belonging to a user.</summary>
        /// <remarks>Log out (service token)</remarks>
        /// <operationid>authn_post_v2_session_logout</operationid>
        /// <param name="userID" type="string">The identity of a user or a service</param>
        /// <returns>Response&lt;SessionLogoutResult&gt;</returns>
        /// <example>
        /// <code>
        /// await client.Session.Logout("pui_xpkhwpnz2cmegsws737xbsqnmnuwtvm5");
        /// </code>
        /// </example>
        public async Task<Response<SessionLogoutResult>> Logout(string userID)
        {
            var request = new SessionLogoutRequest(userID);
            return await DoPost<SessionLogoutResult>("/v2/session/logout", request);
        }

        internal sealed class SessionInvalidateRequest : BaseRequest
        {
            [JsonProperty("session_id")]
            public string SessionID { get; private set; }

            public SessionInvalidateRequest(string sessionID)
            {
                SessionID = sessionID;
            }
        }

        internal sealed class SessionLogoutRequest : BaseRequest
        {
            [JsonProperty("user_id")]
            public string UserID { get; private set; }

            public SessionLogoutRequest(string userID)
            {
                UserID = userID;
            }
        }
    }
}

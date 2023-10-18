using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{

    ///
    public class Session : AuthNBaseClient
    {
        ///
        public Session(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<SessionInvalidateResult>> Invalidate(string sessionID)
        {
            var request = new SessionInvalidateRequest(sessionID);
            return await DoPost<SessionInvalidateResult>("/v2/session/invalidate", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<SessionListResult>> List(SessionListRequest request)
        {
            return await DoPost<SessionListResult>("/v2/session/list", request);
        }

        // TODO: Doc
        ///
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

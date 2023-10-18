using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class ClientSession : AuthNBaseClient
    {
        ///
        public ClientSession(AuthNClient.Builder builder) : base(builder)
        {
        }

        // TODO: Doc
        ///
        public async Task<Response<ClientSessionInvalidateResult>> Invalidate(string token, string sessionID)
        {
            var request = new ClientSessionInvalidateRequest(token, sessionID);
            return await DoPost<ClientSessionInvalidateResult>("/v2/client/session/invalidate", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<ClientSessionListResult>> List(ClientSessionListRequest request)
        {
            return await DoPost<ClientSessionListResult>("/v2/client/session/list", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<ClientSessionLogoutResult>> Logout(string token)
        {
            var request = new ClientSessionLogoutRequest(token);
            return await DoPost<ClientSessionLogoutResult>("/v2/client/session/logout", request);
        }

        // TODO: Doc
        ///
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

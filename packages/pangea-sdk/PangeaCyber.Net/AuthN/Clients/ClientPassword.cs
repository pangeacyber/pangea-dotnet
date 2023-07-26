using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class ClientPassword : AuthNBaseClient
    {
        ///
        public ClientPassword(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<ClientPasswordChangeResult>> Change(string token, string oldPassword, string newPassword)
        {
            var request = new ClientPasswordChangeRequest(token, oldPassword, newPassword);
            return await DoPost<ClientPasswordChangeResult>("/v1/client/password/change", request);
        }

        internal class ClientPasswordChangeRequest : BaseRequest
        {
            [JsonProperty("token")]
            public string Token { get; private set; }

            [JsonProperty("old_password")]
            public string OldPassword { get; private set; }

            [JsonProperty("new_password")]
            public string NewPassword { get; private set; }

            public ClientPasswordChangeRequest(string token, string oldPassword, string newPassword)
            {
                Token = token;
                OldPassword = oldPassword;
                NewPassword = newPassword;
            }
        }
    }
}

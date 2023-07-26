using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserPassword : AuthNBaseClient
    {
        ///
        public UserPassword(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<Dictionary<String, object>>> Reset(string userID, string newPassword)
        {
            var request = new UserPasswordResetRequest(userID, newPassword);
            return await DoPost<Dictionary<String, object>>("/v1/user/password/reset", request);
        }

        internal sealed class UserPasswordResetRequest : BaseRequest
        {
            [JsonProperty("user_id")]
            public string UserID { get; private set; }

            [JsonProperty("new_password")]
            public string NewPassword { get; private set; }

            public UserPasswordResetRequest(string userID, string newPassword)
            {
                UserID = userID;
                NewPassword = newPassword;
            }
        }

    }
}

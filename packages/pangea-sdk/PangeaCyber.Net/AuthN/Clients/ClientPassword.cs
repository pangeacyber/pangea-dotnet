using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class ClientPassword : AuthNBaseClient
    {
        ///
        public ClientPassword(AuthNClient.Builder builder) : base(builder) { }

        /// <kind>method</kind>
        /// <summary>Change a user's password given the current password.</summary>
        /// <remarks>Change a user's password</remarks>
        /// <operationid>authn_post_v2_client_password_change</operationid>
        /// <param name="token" type="string">A user token value</param>
        /// <param name="oldPassword" type="string"></param>
        /// <param name="newPassword" type="string"></param>
        /// <returns>Response&lt;ClientPasswordChangeResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.ClientPassword.Change(
        ///     "ptu_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a",
        ///     "hunter2",
        ///     "My2n+Password"
        /// );
        /// </code>
        /// </example>
        public async Task<Response<ClientPasswordChangeResult>> Change(string token, string oldPassword, string newPassword)
        {
            var request = new ClientPasswordChangeRequest(token, oldPassword, newPassword);
            return await DoPost<ClientPasswordChangeResult>("/v2/client/password/change", request);
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

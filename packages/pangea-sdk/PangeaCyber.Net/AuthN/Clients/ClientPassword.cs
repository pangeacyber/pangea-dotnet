using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;
using PangeaCyber.Net.Exceptions;

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
        /// var response = await client.Client.Password.Change(
        ///     "ptu_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a",
        ///     "hunter2",
        ///     "My2n+Password");
        /// </code>
        /// </example>
        public async Task<Response<ClientPasswordChangeResult>> Change(string token, string oldPassword, string newPassword)
        {
            var request = new ClientPasswordChangeRequest(token, oldPassword, newPassword);
            return await DoPost<ClientPasswordChangeResult>("/v2/client/password/change", request);
        }

        /// <summary>Expire a user's password.</summary>
        /// <remarks>Expire a user's password</remarks>
        /// <operationid>authn_post_v2_user_password_expire</operationid>
        /// <param name="id">The identity of a user or a service.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An empty object.</returns>
        /// <exception cref="PangeaException">Thrown if an error occurs during the operation.</exception>
        /// <exception cref="PangeaAPIException">Thrown if the API returns an error response.</exception>
        /// <example>
        /// <code>
        /// await client.Client.Password.Expire("pui_[...]");
        /// </code>
        /// </example>
        public async Task<Response<object>> Expire(string id, CancellationToken cancellationToken = default)
        {
            return await DoPost<object>(
                "/v2/user/password/expire",
                new ExpirePasswordRequest(id),
                cancellationToken: cancellationToken
            );
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

        internal sealed class ExpirePasswordRequest : BaseRequest
        {
            /// <summary>The identity of a user or a service.</summary>
            [JsonProperty("id")]
            public string ID { get; private set; }

            public ExpirePasswordRequest(string id)
            {
                this.ID = id;
            }
        }
    }
}

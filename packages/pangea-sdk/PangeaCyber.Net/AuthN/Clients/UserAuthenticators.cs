using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class UserAuthenticators : AuthNBaseClient
    {
        ///
        public UserAuthenticators(AuthNClient.Builder builder) : base(builder) { }

        /// <summary>Delete user authenticator.</summary>
        /// <remarks>Delete user authenticator</remarks>
        /// <operationid>authn_post_v2_user_authenticators_delete</operationid>
        /// <param name="request">Request parameters.</param>
        /// <returns>An empty object.</returns>
        /// <example>
        /// <code>
        /// var request = new UserAuthenticatorsDeleteRequest
        ///     .Builder("pau_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a")
        ///     .WithID("pui_xpkhwpnz2cmegsws737xbsqnmnuwtbm5")
        ///     .Build();
        ///
        /// await client.User.Authenticators.Delete(request);
        /// </code>
        /// </example>
        public async Task<Response<object>> Delete(UserAuthenticatorsDeleteRequest request)
        {
            return await DoPost<object>("/v2/user/authenticators/delete", request);
        }

        /// <summary>Get user authenticators.</summary>
        /// <remarks>Get user authenticators</remarks>
        /// <operationid>authn_post_v2_user_authenticators_list</operationid>
        /// <param name="request">Request parameters.</param>
        /// <returns>User's authenticators.</returns>
        /// <example>
        /// <code>
        /// var request = new UserAuthenticatorsListRequest
        ///     .Builder()
        ///     .WithID("pui_xpkhwpnz2cmegsws737xbsqnmnuwtbm5")
        ///     .Build();
        ///
        /// var response = await client.User.Authenticators.List(request);
        /// </code>
        /// </example>
        public async Task<Response<UserAuthenticatorsListResult>> List(UserAuthenticatorsListRequest request)
        {
            return await DoPost<UserAuthenticatorsListResult>("/v2/user/authenticators/list", request);
        }
    }
}

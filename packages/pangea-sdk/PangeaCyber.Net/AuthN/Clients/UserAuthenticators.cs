using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserAuthenticators : AuthNBaseClient
    {
        ///
        public UserAuthenticators(AuthNClient.Builder builder) : base(builder) { }

        /// <kind>method</kind>
        /// <summary>Delete user authenticator.</summary>
        /// <remarks>Delete user authenticator</remarks>
        /// <operationid>authn_post_v2_user_authenticators_delete</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserAuthenticatorsDeleteRequest"></param>
        /// <returns>Response&lt;UserAuthenticatorsDeleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserAuthenticatorsDeleteResult>> Delete(UserAuthenticatorsDeleteRequest request)
        {
            return await DoPost<UserAuthenticatorsDeleteResult>("/v2/user/authenticators/delete", request);
        }

        /// <kind>method</kind>
        /// <summary>Get user authenticators.</summary>
        /// <remarks>Get user authenticators</remarks>
        /// <operationid>authn_post_v2_user_authenticators_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserAuthenticatorsListRequest"></param>
        /// <returns>Response&lt;UserAuthenticatorsListResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserAuthenticatorsListResult>> List(UserAuthenticatorsListRequest request)
        {
            return await DoPost<UserAuthenticatorsListResult>("/v2/user/authenticators/list", request);
        }

    }
}

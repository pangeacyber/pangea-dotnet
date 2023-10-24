using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class User : AuthNBaseClient
    {
        ///
        public UserProfile Profile { get; private set; }
        ///
        public UserInvite Invites { get; private set; }
        ///
        public UserAuthenticators Authenticators { get; private set; }

        ///
        public User(AuthNClient.Builder builder) : base(builder)
        {
            Profile = new UserProfile(builder);
            Invites = new UserInvite(builder);
            Authenticators = new UserAuthenticators(builder);
        }

        /// <kind>method</kind>
        /// <summary>Create a user.</summary>
        /// <remarks>Create User</remarks>
        /// <operationid>authn_post_v2_user_create</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserCreateRequest">The identity of a user or a service</param>
        /// <returns>Response&lt;UserCreateResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserCreateResult>> Create(UserCreateRequest request)
        {
            return await DoPost<UserCreateResult>("/v2/user/create", request);
        }

        /// <kind>method</kind>
        /// <summary>Delete a user by email address.</summary>
        /// <remarks>Delete User</remarks>
        /// <operationid>authn_post_v2_user_delete 1</operationid>
        /// <param name="email" type="string">An email address</param>
        /// <returns>Response&lt;UserDeleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserDeleteResult>> DeleteByEmail(string email)
        {
            var request = new UserDeleteByEmailRequest(email);
            return await DoPost<UserDeleteResult>("/v2/user/delete", request);
        }

        /// <kind>method</kind>
        /// <summary>Delete a user by ID.</summary>
        /// <remarks>Delete User</remarks>
        /// <operationid>authn_post_v2_user_delete 2</operationid>
        /// <param name="id" type="string">The identity of a user or a service</param>
        /// <returns>Response&lt;UserDeleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserDeleteResult>> DeleteByID(string id)
        {
            var request = new UserDeleteByIDRequest(id);
            return await DoPost<UserDeleteResult>("/v2/user/delete", request);
        }

        /// <kind>method</kind>
        /// <summary>Update user's settings.</summary>
        /// <remarks>Update user's settings</remarks>
        /// <operationid>authn_post_v2_user_update</operationid>
        /// <param name="request" type="string">The identity of a user or a service</param>
        /// <returns>Response&lt;UserDeleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserUpdateResult>> Update(UserUpdateRequest request)
        {
            return await DoPost<UserUpdateResult>("/v2/user/update", request);
        }

        /// <kind>method</kind>
        /// <summary>Send an invitation to a user.</summary>
        /// <remarks>Invite User</remarks>
        /// <operationid>authn_post_v2_user_invite</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserInviteRequest"></param>
        /// <returns>Response&lt;UserInviteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserInviteResult>> Invite(UserInviteRequest request)
        {
            return await DoPost<UserInviteResult>("/v2/user/invite", request);
        }

        /// <kind>method</kind>
        /// <summary>Look up users by scopes.</summary>
        /// <remarks>List Users</remarks>
        /// <operationid>authn_post_v2_user_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserListRequest"></param>
        /// <returns>Response&lt;UserListResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserListResult>> List(UserListRequest request)
        {
            return await DoPost<UserListResult>("/v2/user/list", request);
        }

        internal sealed class UserDeleteByEmailRequest : BaseRequest
        {
            [JsonProperty("email")]
            public string Email { get; private set; }

            public UserDeleteByEmailRequest(string email)
            {
                Email = email;
            }
        }

        internal sealed class UserDeleteByIDRequest : BaseRequest
        {
            [JsonProperty("id")]
            public string ID { get; private set; }

            public UserDeleteByIDRequest(string id)
            {
                ID = id;
            }
        }

    }
}

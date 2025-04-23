using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients;

/// <summary>
/// AuthN Client
/// </summary>
public class User : AuthNBaseClient
{
    /// <summary>Authenticators</summary>
    public UserAuthenticators Authenticators { get; private set; }

    /// <summary>Invites</summary>
    public UserInvite Invites { get; private set; }

    /// <summary>Profile</summary>
    public UserProfile Profile { get; private set; }

    /// <summary>Group</summary>
    public UserGroup Group { get; private set; }


    /// <summary>Constructor.</summary>
    public User(AuthNClient.Builder builder) : base(builder)
    {
        this.Authenticators = new UserAuthenticators(builder);
        this.Group = new UserGroup(builder);
        this.Invites = new UserInvite(builder);
        this.Profile = new UserProfile(builder);
    }

    /// <kind>method</kind>
    /// <summary>Create a user.</summary>
    /// <remarks>Create User</remarks>
    /// <operationid>authn_post_v2_user_create</operationid>
    /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserCreateRequest">The identity of a user or a service</param>
    /// <returns>Response&lt;UserCreateResult&gt;</returns>
    /// <example>
    /// <code>
    /// Profile profile = new Profile();
    /// profile.FirstName = "Joe";
    /// profile.LastName = "User";
    ///
    /// var request = new UserCreateRequest
    ///     .Builder("joe.user@pangea.cloud", profile)
    ///     .Build();
    ///
    /// var response = await client.User.Create(request);
    /// </code>
    /// </example>
    public async Task<Response<UserCreateResult>> Create(UserCreateRequest request)
    {
        return await DoPost<UserCreateResult>("/v2/user/create", request);
    }

    /// <summary>Delete a user by email address.</summary>
    /// <remarks>Delete User - Email</remarks>
    /// <operationid>authn_post_v2_user_delete 1</operationid>
    /// <param name="email">An email address</param>
    /// <returns>An empty object.</returns>
    /// <example>
    /// <code>
    /// await client.User.DeleteByEmail("joe.user@pangea.cloud");
    /// </code>
    /// </example>
    public async Task<Response<UserDeleteResult>> DeleteByEmail(string email)
    {
        var request = new UserDeleteByEmailRequest(email);
        return await DoPost<UserDeleteResult>("/v2/user/delete", request);
    }

    /// <summary>Delete a user by ID.</summary>
    /// <remarks>Delete User - ID</remarks>
    /// <operationid>authn_post_v2_user_delete 2</operationid>
    /// <param name="id">The identity of a user or a service</param>
    /// <returns>An empty object.</returns>
    /// <example>
    /// <code>
    /// await client.User.DeleteByID("pui_xpkhwpnz2cmegsws737xbsqnmnuwtbm5");
    /// </code>
    /// </example>
    public async Task<Response<UserDeleteResult>> DeleteByID(string id)
    {
        var request = new UserDeleteByIDRequest(id);
        return await DoPost<UserDeleteResult>("/v2/user/delete", request);
    }

    /// <summary>Delete a user by username.</summary>
    /// <remarks>Delete User - Username</remarks>
    /// <operationid>authn_post_v2_user_delete 3</operationid>
    /// <param name="username">A username.</param>
    /// <returns>An empty object.</returns>
    /// <example>
    /// <code>
    /// await client.User.DeleteByUsername("foobar");
    /// </code>
    /// </example>
    public async Task<Response<UserDeleteResult>> DeleteByUsername(string username)
    {
        return await DoPost<UserDeleteResult>(
            "/v2/user/delete",
            new UserDeleteByUsernameRequest { Username = username }
        );
    }

    /// <summary>Update user's settings.</summary>
    /// <remarks>Update user's settings</remarks>
    /// <operationid>authn_post_v2_user_update</operationid>
    /// <param name="request">Request parameters.</param>
    /// <returns>The updated user.</returns>
    /// <example>
    /// <code>
    /// var request = new UserUpdateRequest
    ///     .Builder()
    ///     .WithEmail("joe.user@pangea.cloud")
    ///     .WithDisabled(true)
    ///     .Build();
    ///
    /// var response = await client.User.Update(request);
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
    /// var request = new UserInviteRequest
    ///     .Builder(
    ///         "admin@pangea.cloud",
    ///         "joe.user@pangea.cloud",
    ///         "https://www.myserver.com/callback",
    ///         "pcb_zurr3lkcwdp5keq73htsfpcii5k4zgm7")
    ///     .Build();
    ///
    /// var response = await client.User.Invite(request);
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
    /// var request = new UserListRequest.Builder().Build();
    ///
    /// var response = await client.User.List(request);
    /// </code>
    /// </example>
    public async Task<Response<UserListResult>> List(UserListRequest request)
    {
        return await DoPost<UserListResult>("/v2/user/list", request);
    }

    internal sealed class UserDeleteByEmailRequest : BaseRequest
    {
        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string Email { get; private set; }

        public UserDeleteByEmailRequest(string email)
        {
            Email = email;
        }
    }

    internal sealed class UserDeleteByIDRequest : BaseRequest
    {
        /// <summary>The id of a user or a service.</summary>
        [JsonProperty("id")]
        public string ID { get; private set; }

        public UserDeleteByIDRequest(string id)
        {
            ID = id;
        }
    }

    internal sealed class UserDeleteByUsernameRequest : BaseRequest
    {
        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string Username { get; set; } = default!;
    }
}

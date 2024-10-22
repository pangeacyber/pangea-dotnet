using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class UserProfile : AuthNBaseClient
    {
        ///
        public UserProfile(AuthNClient.Builder builder) : base(builder) { }

        /// <summary>Get user's information by email.</summary>
        /// <remarks>Get user - email</remarks>
        /// <operationid>authn_post_v2_user_profile_get 1</operationid>
        /// <param name="email">An email address.</param>
        /// <returns>User's profile.</returns>
        /// <example>
        /// <code>
        /// var response = await client.User.Profile.GetByEmail("joe.user@pangea.cloud");
        /// </code>
        /// </example>
        public async Task<Response<UserProfileGetResult>> GetByEmail(string email)
        {
            return await DoPost<UserProfileGetResult>(
                "/v2/user/profile/get",
                new UserProfileGetRequest { Email = email }
            );
        }

        /// <summary>Get user's information by id.</summary>
        /// <remarks>Get user - id</remarks>
        /// <operationid>authn_post_v2_user_profile_get 2</operationid>
        /// <param name="id">The identity of a user or a service.</param>
        /// <returns>User's profile.</returns>
        /// <example>
        /// <code>
        /// var response = await client.User.Profile.GetByID("pui_xpkhwpnz2cmegsws737xbsqnmnuwtbm5");
        /// </code>
        /// </example>
        public async Task<Response<UserProfileGetResult>> GetByID(string id)
        {
            return await DoPost<UserProfileGetResult>(
                "/v2/user/profile/get",
                new UserProfileGetRequest { ID = id }
            );
        }

        /// <summary>Get user's information by username.</summary>
        /// <remarks>Get user - username</remarks>
        /// <operationid>authn_post_v2_user_profile_get 3</operationid>
        /// <param name="username">A username.</param>
        /// <returns>User's profile.</returns>
        /// <example>
        /// <code>
        /// var response = await client.User.Profile.GetByUsername("foobar");
        /// </code>
        /// </example>
        public async Task<Response<UserProfileGetResult>> GetByUsername(string username)
        {
            return await DoPost<UserProfileGetResult>(
                "/v2/user/profile/get",
                new UserProfileGetRequest { Username = username }
            );
        }

        /// <summary>Update user's information by identity or email.</summary>
        /// <remarks>Update user</remarks>
        /// <operationid>authn_post_v2_user_profile_update</operationid>
        /// <param name="request">Request parameters.</param>
        /// <returns>Updated user profile.</returns>
        /// <example>
        /// <code>
        /// Profile updatedProfile = new Profile()
        /// {
        ///     { "country", "Argentina" }
        /// };
        ///
        /// var request = new UserProfileUpdateRequest
        ///     .Builder(updatedProfile)
        ///     .WithID("pui_xpkhwpnz2cmegsws737xbsqnmnuwtbm5")
        ///     .Build();
        ///
        /// var response = await client.User.Profile.Update(request);
        /// </code>
        /// </example>
        public async Task<Response<UserProfileUpdateResult>> Update(UserProfileUpdateRequest request)
        {
            return await DoPost<UserProfileUpdateResult>("/v2/user/profile/update", request);
        }

        internal sealed class UserProfileGetRequest : BaseRequest
        {
            /// <summary>An email address.</summary>
            [JsonProperty("email")]
            public string? Email { get; set; }

            /// <summary>The identity of a user or a service.</summary>
            [JsonProperty("id")]
            public string? ID { get; set; }

            /// <summary>A username.</summary>
            [JsonProperty("username")]
            public string? Username { get; set; }
        }
    }
}

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

        /// <kind>method</kind>
        /// <summary>Get user's information by email.</summary>
        /// <remarks>Get user - email</remarks>
        /// <operationid>authn_post_v2_user_profile_get 1</operationid>
        /// <param name="email" type="string"></param>
        /// <returns>Response&lt;UserProfileGetResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.User.Profile.GetByEmail("joe.user@pangea.cloud");
        /// </code>
        /// </example>
        public async Task<Response<UserProfileGetResult>> GetByEmail(string email)
        {
            var request = new UserProfileGetRequest(email, null);
            return await DoPost<UserProfileGetResult>("/v2/user/profile/get", request);
        }

        /// <kind>method</kind>
        /// <summary>Get user's information by id.</summary>
        /// <remarks>Get user - id</remarks>
        /// <operationid>authn_post_v2_user_profile_get 2</operationid>
        /// <param name="id" type="string"></param>
        /// <returns>Response&lt;UserProfileGetResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.User.Profile.GetByID("pui_xpkhwpnz2cmegsws737xbsqnmnuwtbm5");
        /// </code>
        /// </example>
        public async Task<Response<UserProfileGetResult>> GetByID(string id)
        {
            var request = new UserProfileGetRequest(null, id);
            return await DoPost<UserProfileGetResult>("/v2/user/profile/get", request);
        }

        /// <kind>method</kind>
        /// <summary>Update user's information by identity or email.</summary>
        /// <remarks>Update user</remarks>
        /// <operationid>authn_post_v2_user_profile_update</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserProfileUpdateRequest"></param>
        /// <returns>Response&lt;UserProfileUpdateResult&gt;</returns>
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
            [JsonProperty("email")]
            public string? Email { get; private set; }

            [JsonProperty("id")]
            public string? ID { get; private set; }

            public UserProfileGetRequest(string? email, string? id)
            {
                Email = email;
                ID = id;
            }
        }
    }
}

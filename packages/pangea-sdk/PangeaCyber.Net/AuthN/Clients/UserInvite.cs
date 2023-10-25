using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class UserInvite : AuthNBaseClient
    {
        ///
        public UserInvite(AuthNClient.Builder builder) : base(builder) { }

        /// <kind>method</kind>
        /// <summary>Look up active invites for the userpool.</summary>
        /// <remarks>List Invites</remarks>
        /// <operationid>authn_post_v2_user_invite_list</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.UserInviteListRequest"></param>
        /// <returns>Response&lt;UserInviteListResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserInviteListResult>> List(UserInviteListRequest request)
        {
            return await DoPost<UserInviteListResult>("/v2/user/invite/list", request);
        }

        /// <kind>method</kind>
        /// <summary>Delete a user invitation.</summary>
        /// <remarks>Delete Invite</remarks>
        /// <operationid>authn_post_v2_user_invite_delete</operationid>
        /// <param name="id" type="string">A one-time ticket</param>
        /// <returns>Response&lt;UserInviteDeleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<UserInviteDeleteResult>> Delete(string id)
        {
            var request = new UserInviteDeleteRequest(id);
            return await DoPost<UserInviteDeleteResult>("/v2/user/invite/delete", request);
        }

        internal sealed class UserInviteDeleteRequest : BaseRequest
        {
            [JsonProperty("id")]
            public string ID { get; private set; }

            public UserInviteDeleteRequest(string id)
            {
                ID = id;
            }
        }

    }
}

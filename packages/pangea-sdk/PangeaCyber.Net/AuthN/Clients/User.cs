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

        // TODO: Doc
        ///
        public async Task<Response<UserCreateResult>> Create(UserCreateRequest request)
        {
            return await DoPost<UserCreateResult>("/v2/user/create", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserDeleteResult>> DeleteByEmail(string email)
        {
            var request = new UserDeleteByEmailRequest(email);
            return await DoPost<UserDeleteResult>("/v2/user/delete", request);
        }

        ///
        public async Task<Response<UserDeleteResult>> DeleteByID(string id)
        {
            var request = new UserDeleteByIDRequest(id);
            return await DoPost<UserDeleteResult>("/v2/user/delete", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserUpdateResult>> Update(UserUpdateRequest request)
        {
            return await DoPost<UserUpdateResult>("/v2/user/update", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserInviteResult>> Invite(UserInviteRequest request)
        {
            return await DoPost<UserInviteResult>("/v2/user/invite", request);
        }

        // TODO: Doc
        ///
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

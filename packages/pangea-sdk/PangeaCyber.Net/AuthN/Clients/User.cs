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
        public UserMFA MFA { get; private set; }
        ///
        public UserLogin Login { get; private set; }
        ///
        public UserPassword Password { get; private set; }

        ///
        public User(AuthNClient.Builder builder) : base(builder)
        {
            Profile = new UserProfile(builder);
            Invites = new UserInvite(builder);
            MFA = new UserMFA(builder);
            Login = new UserLogin(builder);
            Password = new UserPassword(builder);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserCreateResult>> Create(UserCreateRequest request)
        {
            return await DoPost<UserCreateResult>("/v1/user/create", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserDeleteResult>> DeleteByEmail(string email)
        {
            var request = new UserDeleteByEmailRequest(email);
            return await DoPost<UserDeleteResult>("/v1/user/delete", request);
        }

        ///
        public async Task<Response<UserDeleteResult>> DeleteByID(string id)
        {
            var request = new UserDeleteByIDRequest(id);
            return await DoPost<UserDeleteResult>("/v1/user/delete", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserUpdateResult>> Update(UserUpdateRequest request)
        {
            return await DoPost<UserUpdateResult>("/v1/user/update", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserInviteResult>> Invite(UserInviteRequest request)
        {
            return await DoPost<UserInviteResult>("/v1/user/invite", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserListResult>> List(UserListRequest request)
        {
            return await DoPost<UserListResult>("/v1/user/list", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserVerifyResult>> Verify(Models.IDProvider idProvider, string email, string authenticator)
        {
            var request = new UserVerifyRequest(idProvider, email, authenticator);
            return await DoPost<UserVerifyResult>("/v1/user/verify", request);
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

        internal sealed class UserVerifyRequest : BaseRequest
        {
            [JsonProperty("id_provider")]
            public Models.IDProvider IDProvider { get; private set; }

            [JsonProperty("email")]
            public string Email { get; private set; }

            [JsonProperty("authenticator")]
            public string Authenticator { get; private set; }

            public UserVerifyRequest(Models.IDProvider idProvider, string email, string authenticator)
            {
                IDProvider = idProvider;
                Email = email;
                Authenticator = authenticator;
            }
        }


    }
}

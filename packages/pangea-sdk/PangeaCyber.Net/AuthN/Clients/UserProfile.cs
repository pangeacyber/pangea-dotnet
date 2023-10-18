using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserProfile : AuthNBaseClient
    {
        ///
        public UserProfile(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<UserProfileGetResult>> GetByEmail(string email)
        {
            var request = new UserProfileGetRequest(email, null);
            return await DoPost<UserProfileGetResult>("/v2/user/profile/get", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserProfileGetResult>> GetByID(string id)
        {
            var request = new UserProfileGetRequest(null, id);
            return await DoPost<UserProfileGetResult>("/v2/user/profile/get", request);
        }

        // TODO: Doc
        ///
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

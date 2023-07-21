using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserInvite : AuthNBaseClient
    {
        ///
        public UserInvite(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<UserInviteListResult>> List(UserInviteListRequest request)
        {
            return await DoPost<UserInviteListResult>("/v1/user/invite/list", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserInviteDeleteResult>> Delete(string id)
        {
            var request = new UserInviteDeleteRequest(id);
            return await DoPost<UserInviteDeleteResult>("/v1/user/invite/delete", request);
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

using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserAuthenticators : AuthNBaseClient
    {
        ///
        public UserAuthenticators(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<UserAuthenticatorsDeleteResult>> Delete(UserAuthenticatorsDeleteRequest request)
        {
            return await DoPost<UserAuthenticatorsDeleteResult>("/v2/user/authenticators/delete", request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<UserAuthenticatorsListResult>> List(UserAuthenticatorsListRequest request)
        {
            return await DoPost<UserAuthenticatorsListResult>("/v2/user/authenticators/list", request);
        }

    }
}

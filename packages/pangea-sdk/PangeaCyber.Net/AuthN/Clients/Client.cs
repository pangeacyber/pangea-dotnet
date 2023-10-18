using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class Client : AuthNBaseClient
    {
        ///
        public ClientSession Session { get; private set; }
        ///
        public ClientPassword Password { get; private set; }
        ///
        public ClientToken Token { get; private set; }

        ///
        public Client(AuthNClient.Builder builder) : base(builder)
        {
            Session = new ClientSession(builder);
            Password = new ClientPassword(builder);
            Token = new ClientToken(builder);
        }

        // TODO: Doc
        ///
        public async Task<Response<ClientUserinfoResult>> Userinfo(string code)
        {
            UserinfoRequest request = new UserinfoRequest(code);
            return await DoPost<ClientUserinfoResult>("/v2/client/userinfo", request);
        }

        ///
        public async Task<Response<ClientJWKSResult>> Jwks()
        {
            return await DoPost<ClientJWKSResult>("/v2/client/jwks", new BaseRequest());
        }

        internal class UserinfoRequest : BaseRequest
        {
            [JsonProperty("code")]
            public string Code { get; private set; }

            public UserinfoRequest(string code)
            {
                Code = code;
            }
        }
    }
}

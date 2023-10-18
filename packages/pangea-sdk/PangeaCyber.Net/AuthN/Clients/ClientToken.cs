using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class ClientToken : AuthNBaseClient
    {
        ///
        public ClientToken(AuthNClient.Builder builder) : base(builder)
        {
        }

        // TODO: Doc
        ///
        public async Task<Response<ClientTokenCheckResult>> Check(string token)
        {
            TokenCheckRequest request = new TokenCheckRequest(token);
            return await DoPost<ClientTokenCheckResult>("/v2/client/token/check", request);
        }

        internal class TokenCheckRequest : BaseRequest
        {
            [JsonProperty("token")]
            public string Token { get; private set; }

            public TokenCheckRequest(string token)
            {
                Token = token;
            }
        }
    }
}

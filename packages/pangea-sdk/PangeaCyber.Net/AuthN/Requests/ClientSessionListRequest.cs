using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class ClientSessionListRequest : CommonSessionListRequest<ClientSessionListRequest.Builder>
    {
        ///
        [JsonProperty("token")]
        public string Token { get; private set; }

        private ClientSessionListRequest(Builder builder) : base(builder)
        {
            Token = builder.Token;
        }

        ///
        public class Builder : CommonBuilder
        {
            ///
            public string Token { get; private set; }

            ///
            public Builder(string token)
            {
                Token = token;
            }

            ///
            public new ClientSessionListRequest Build()
            {
                return new ClientSessionListRequest(this);
            }
        }
    }
}

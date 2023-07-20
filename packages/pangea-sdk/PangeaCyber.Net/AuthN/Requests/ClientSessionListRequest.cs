using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class ClientSessionListRequest : CommonSessionListRequest<ClientSessionListRequest.Builder>
    {
        ///
        [JsonProperty("token")]
        public string Token { get; private set; }

        private ClientSessionListRequest(Builder builder) : base(builder)
        {
            this.Token = builder.Token;
        }

        ///
        public class Builder : CommonSessionListRequest<ClientSessionListRequest.Builder>.CommonBuilder
        {
            ///
            public string Token { get; private set; }

            ///
            public Builder(string token)
            {
                this.Token = token;
            }

            ///
            public new ClientSessionListRequest Build()
            {
                return new ClientSessionListRequest(this);
            }
        }
    }
}

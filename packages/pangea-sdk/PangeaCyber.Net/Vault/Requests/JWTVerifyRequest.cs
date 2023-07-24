using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class JWTVerifyRequest : BaseRequest
    {
        ///
        [JsonProperty("jws")]
        public string JWS { get; private set; }

        ///
        private JWTVerifyRequest(Builder builder)
        {
            JWS = builder.JWS;
        }

        ///
        public class Builder
        {
            ///
            public string JWS { get; private set; }

            ///
            public Builder(string jws)
            {
                JWS = jws;
            }

            ///
            public JWTVerifyRequest Build()
            {
                return new JWTVerifyRequest(this);
            }
        }
    }
}

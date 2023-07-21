using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class JWTSignRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("payload")]
        public string Payload { get; private set; }

        ///
        private JWTSignRequest(Builder builder)
        {
            ID = builder.ID;
            Payload = builder.Payload;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }

            ///
            public string Payload { get; private set; }

            ///
            public Builder(string id, string payload)
            {
                ID = id;
                Payload = payload;
            }

            ///
            public JWTSignRequest Build()
            {
                return new JWTSignRequest(this);
            }
        }
    }
}

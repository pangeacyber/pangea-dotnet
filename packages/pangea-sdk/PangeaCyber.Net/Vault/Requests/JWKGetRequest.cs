using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class JWKGetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("version")]
        public string Version { get; private set; }

        ///
        private JWKGetRequest(Builder builder)
        {
            ID = builder.ID;
            Version = builder.Version;
        }

        ///
        public class Builder
        {
            ///
            public string ID { get; private set; }

            ///
            public string Version { get; private set; }

            ///
            public Builder(string id, string version)
            {
                ID = id;
                Version = version;
            }

            ///
            public JWKGetRequest Build()
            {
                return new JWKGetRequest(this);
            }
        }
    }
}

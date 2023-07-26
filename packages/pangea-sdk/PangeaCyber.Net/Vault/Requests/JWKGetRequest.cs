using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class JWKGetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; }

        ///
        [JsonProperty("version")]
        public string? Version { get; private set; }

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
            public string? Version { get; private set; }

            ///
            public Builder(string id)
            {
                ID = id;
            }

            ///
            public Builder WithVersion(string version)
            {
                Version = version;
                return this;
            }

            ///
            public JWKGetRequest Build()
            {
                return new JWKGetRequest(this);
            }
        }
    }
}

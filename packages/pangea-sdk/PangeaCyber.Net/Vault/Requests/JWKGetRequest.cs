using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class JWKGetRequest : BaseRequest
    {
        ///
        [JsonProperty("id")]
        public string Id { get; private set; }

        ///
        [JsonProperty("version")]
        public string Version { get; private set; }

        ///
        private JWKGetRequest(Builder builder)
        {
            Id = builder.Id;
            Version = builder.Version;
        }

        ///
        public class Builder
        {
            ///
            public string Id { get; private set; }

            ///
            public string Version { get; private set; }

            ///
            public Builder(string id, string version)
            {
                Id = id;
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

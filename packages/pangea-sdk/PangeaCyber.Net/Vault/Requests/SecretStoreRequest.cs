using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SecretStoreRequest : CommonStoreRequest<SecretStoreRequest.Builder>
    {
        ///
        [JsonProperty("secret")]
        public string Secret { get; private set; }

        ///
        [JsonProperty("type")]
        public string Type { get; private set; }

        ///
        protected SecretStoreRequest(Builder builder)
            : base(builder)
        {
            Secret = builder.Secret;
            Type = "secret";
        }

        ///
        public class Builder : CommonStoreRequest<SecretStoreRequest.Builder>.CommonBuilder
        {
            ///
            public string Secret { get; private set; }

            ///
            public Builder(string secret, string name)
                : base(name)
            {
                Secret = secret;
            }

            ///
            public new SecretStoreRequest Build()
            {
                return new SecretStoreRequest(this);
            }
        }
    }
}

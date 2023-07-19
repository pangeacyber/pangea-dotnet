using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class SecretRotateRequest : CommonRotateRequest<SecretRotateRequest.Builder>
    {
        ///
        [JsonProperty("secret")]
        public string? Secret { get; private set; }

        ///
        protected SecretRotateRequest(Builder builder) : base(builder)
        {
            Secret = builder.Secret;
        }

        ///
        public class Builder : CommonRotateRequest<Builder>.CommonBuilder
        {
            ///
            public string? Secret { get; private set; }

            ///
            public Builder(string id, string secret) : base(id)
            {
                Secret = secret;
            }

            ///
            public new SecretRotateRequest Build()
            {
                return new SecretRotateRequest(this);
            }

            ///
            public Builder WithSecret(string secret)
            {
                Secret = secret;
                return this;
            }
        }
    }
}

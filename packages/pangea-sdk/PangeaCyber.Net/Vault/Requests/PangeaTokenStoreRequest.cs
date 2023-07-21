using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class PangeaTokenStoreRequest : CommonStoreRequest<PangeaTokenStoreRequest.Builder>
    {
        ///
        [JsonProperty("secret")]
        public string Token { get; set; }

        ///
        [JsonProperty("type")]
        public string Type { get; private set; }

        ///
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; set; }

        ///
        protected PangeaTokenStoreRequest(Builder builder)
            : base(builder)
        {
            Token = builder.Token;
            RotationGracePeriod = builder.RotationGracePeriod;
            Type = "pangea_token";
        }

        ///
        public class Builder : CommonStoreRequest<Builder>.CommonBuilder
        {
            ///
            public string Token { get; private set; }

            ///
            public string? RotationGracePeriod { get; private set; }

            ///
            public Builder(string token, string name)
                : base(name)
            {
                Token = token;
            }

            ///
            public new PangeaTokenStoreRequest Build()
            {
                return new PangeaTokenStoreRequest(this);
            }

            ///
            public Builder WithRotationGracePeriod(string rotationGracePeriod)
            {
                RotationGracePeriod = rotationGracePeriod;
                return this;
            }
        }
    }
}

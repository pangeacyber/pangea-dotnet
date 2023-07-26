using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserLoginRequest : BaseRequest
    {
        ///
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///
        [JsonProperty("secret")]
        public string Secret { get; private set; }

        ///
        [JsonProperty("scopes")]
        public Scopes? Scopes { get; private set; }

        ///
        private UserLoginRequest(Builder builder)
        {
            this.Email = builder.Email;
            this.Secret = builder.Secret;
            this.Scopes = builder.Scopes;
        }

        ///
        public class Builder
        {
            ///
            public string Email { get; private set; }
            ///
            public string Secret { get; private set; }
            ///
            public Scopes? Scopes { get; private set; }

            ///
            public Builder(string email, string secret)
            {
                this.Email = email;
                this.Secret = secret;
            }

            ///
            public Builder WithScopes(Scopes scopes)
            {
                this.Scopes = scopes;
                return this;
            }

            ///
            public UserLoginRequest Build()
            {
                return new UserLoginRequest(this);
            }
        }
    }
}

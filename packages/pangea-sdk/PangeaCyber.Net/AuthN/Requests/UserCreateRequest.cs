using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///
        [JsonProperty("authenticator")]
        public string Authenticator { get; private set; }

        ///
        [JsonProperty("id_provider")]
        public IDProvider IDProvider { get; private set; }

        ///
        [JsonProperty("verified")]
        public bool? Verified { get; private set; }

        ///
        [JsonProperty("require_mfa")]
        public bool? RequireMFA { get; private set; }

        ///
        [JsonProperty("scopes")]
        public Scopes? Scopes { get; private set; }

        ///
        [JsonProperty("profile")]
        public Profile? Profile { get; private set; }

        private UserCreateRequest(Builder builder)
        {
            this.Email = builder.Email;
            this.Authenticator = builder.Authenticator;
            this.IDProvider = builder.IDProvider;
            this.Verified = builder.Verified;
            this.RequireMFA = builder.RequireMFA;
            this.Scopes = builder.Scopes;
            this.Profile = builder.Profile;
        }

        ///
        public class Builder
        {
            ///
            public string Email { get; private set; }
            ///
            public string Authenticator { get; private set; }
            ///
            public IDProvider IDProvider { get; private set; }
            ///
            public bool? Verified { get; private set; }
            ///
            public bool? RequireMFA { get; private set; }
            ///
            public Scopes? Scopes { get; private set; }
            ///
            public Profile? Profile { get; private set; }

            ///
            public Builder(string email, string authenticator, IDProvider idProvider)
            {
                this.Email = email;
                this.Authenticator = authenticator;
                this.IDProvider = idProvider;
            }

            ///
            public Builder WithVerified(bool? verified)
            {
                this.Verified = verified;
                return this;
            }

            ///
            public Builder WithRequireMFA(bool? requireMFA)
            {
                this.RequireMFA = requireMFA;
                return this;
            }

            ///
            public Builder WithScopes(Scopes scopes)
            {
                this.Scopes = scopes;
                return this;
            }

            ///
            public Builder WithProfile(Profile profile)
            {
                this.Profile = profile;
                return this;
            }

            ///
            public UserCreateRequest Build()
            {
                return new UserCreateRequest(this);
            }
        }
    }
}

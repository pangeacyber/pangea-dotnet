using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserUpdateRequest : BaseRequest
    {
        ///
        [JsonProperty("email")]
        public string? Email { get; private set; }

        ///
        [JsonProperty("authenticator")]
        public string? Authenticator { get; private set; }

        ///
        [JsonProperty("id")]
        public IDProvider? ID { get; private set; }

        ///
        [JsonProperty("disabled")]
        public bool? Disabled { get; private set; }

        ///
        [JsonProperty("require_mfa")]
        public bool? RequireMFA { get; private set; }

        ///
        [JsonProperty("verified")]
        public bool? Verified { get; private set; }

        private UserUpdateRequest(Builder builder)
        {
            this.ID = builder.ID;
            this.Email = builder.Email;
            this.Authenticator = builder.Authenticator;
            this.Disabled = builder.Disabled;
            this.RequireMFA = builder.RequireMFA;
            this.Verified = builder.Verified;
        }

        ///
        public class Builder
        {
            ///
            public IDProvider? ID { get; private set; }
            ///
            public string? Email { get; private set; }
            ///
            public string? Authenticator { get; private set; }
            ///
            public bool? Disabled { get; private set; }
            ///
            public bool? RequireMFA { get; private set; }
            ///
            public bool? Verified { get; private set; }

            ///
            public Builder() { }

            ///
            public Builder WithId(IDProvider id)
            {
                this.ID = id;
                return this;
            }

            ///
            public Builder WithEmail(string email)
            {
                this.Email = email;
                return this;
            }

            ///
            public Builder WithAuthenticator(string authenticator)
            {
                this.Authenticator = authenticator;
                return this;
            }

            ///
            public Builder WithDisabled(bool? disabled)
            {
                this.Disabled = disabled;
                return this;
            }

            ///
            public Builder WithRequireMFA(bool? requireMFA)
            {
                this.RequireMFA = requireMFA;
                return this;
            }

            ///
            public Builder WithVerified(bool? verified)
            {
                this.Verified = verified;
                return this;
            }

            ///
            public UserUpdateRequest Build()
            {
                return new UserUpdateRequest(this);
            }
        }
    }
}

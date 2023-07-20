using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserInviteRequest : BaseRequest
    {
        ///
        [JsonProperty("inviter")]
        public string Inviter { get; private set; }

        ///
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///
        [JsonProperty("callback")]
        public string Callback { get; private set; }

        ///
        [JsonProperty("state")]
        public string State { get; private set; }

        ///
        [JsonProperty("require_mfa")]
        public bool? RequireMFA { get; private set; }

        private UserInviteRequest(Builder builder)
        {
            this.Inviter = builder.Inviter;
            this.Email = builder.Email;
            this.Callback = builder.Callback;
            this.State = builder.State;
            this.RequireMFA = builder.RequireMFA;
        }

        ///
        public class Builder
        {
            ///
            public string Inviter { get; private set; }
            ///
            public string Email { get; private set; }
            ///
            public string Callback { get; private set; }
            ///
            public string State { get; private set; }
            ///
            public bool? RequireMFA { get; private set; }

            ///
            public Builder(string inviter, string email, string callback, string state)
            {
                this.Inviter = inviter;
                this.Email = email;
                this.Callback = callback;
                this.State = state;
            }

            ///
            public Builder WithRequireMFA(bool? requireMFA)
            {
                this.RequireMFA = requireMFA;
                return this;
            }

            ///
            public UserInviteRequest Build()
            {
                return new UserInviteRequest(this);
            }
        }
    }
}

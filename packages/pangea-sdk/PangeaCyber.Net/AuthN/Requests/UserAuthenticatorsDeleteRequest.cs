using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserAuthenticatorsDeleteRequest : BaseRequest
    {
        ///
        [JsonProperty("authenticator_id")]
        public string AuthenticatorID { get; private set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; private set; }

        ///
        [JsonProperty("email")]
        public string? Email { get; private set; }

        private UserAuthenticatorsDeleteRequest(Builder builder)
        {
            AuthenticatorID = builder.AuthenticatorID;
            ID = builder.ID;
            Email = builder.Email;
        }

        ///
        public class Builder
        {
            ///
            public string AuthenticatorID { get; }

            ///
            public string? ID { get; private set; }

            ///
            public string? Email { get; private set; }

            ///
            public Builder(string authenticatorID)
            {
                AuthenticatorID = authenticatorID;
            }

            ///
            public Builder WithID(string id)
            {
                ID = id;
                return this;
            }

            ///
            public Builder WithEmail(string email)
            {
                Email = email;
                return this;
            }

            ///
            public UserAuthenticatorsDeleteRequest Build()
            {
                return new UserAuthenticatorsDeleteRequest(this);
            }
        }
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserAuthenticatorsDeleteRequest : BaseRequest
    {
        /// <summary>An ID for an authenticator.</summary>
        [JsonProperty("authenticator_id")]
        public string AuthenticatorID { get; private set; }

        /// <summary>The identity of a user or a service.</summary>
        [JsonProperty("id")]
        public string? ID { get; private set; }

        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string? Email { get; private set; }

        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string? Username { get; private set; }

        private UserAuthenticatorsDeleteRequest(Builder builder)
        {
            AuthenticatorID = builder.AuthenticatorID;
            ID = builder.ID;
            Email = builder.Email;
            Username = builder.Username;
        }

        ///
        public class Builder
        {
            /// <inheritdoc cref="UserAuthenticatorsDeleteRequest.AuthenticatorID" />
            public string AuthenticatorID { get; }

            /// <inheritdoc cref="UserAuthenticatorsDeleteRequest.ID" />
            public string? ID { get; private set; }

            /// <inheritdoc cref="UserAuthenticatorsDeleteRequest.Email" />
            public string? Email { get; private set; }

            /// <inheritdoc cref="UserAuthenticatorsDeleteRequest.Username" />
            public string? Username { get; private set; }

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

            /// <summary>Add a username to the request parameters.</summary>
            /// <param name="username">A username.</param>
            /// <returns>Builder.</returns>
            public Builder WithUsername(string username)
            {
                Username = username;
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

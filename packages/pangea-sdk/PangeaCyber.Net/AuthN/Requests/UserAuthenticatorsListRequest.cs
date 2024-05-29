using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    /// <summary>
    ///
    /// </summary>
    public class UserAuthenticatorsListRequest : BaseRequest
    {
        /// <summary>The identity of a user or a service.</summary>
        [JsonProperty("id")]
        public string? ID { get; private set; }

        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string? Email { get; private set; }

        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string? Username { get; private set; }

        private UserAuthenticatorsListRequest(Builder builder)
        {
            ID = builder.ID;
            Email = builder.Email;
            Username = builder.Username;
        }

        /// <summary>
        /// Builder class for <see cref="UserAuthenticatorsListRequest"/>.
        /// </summary>
        public class Builder
        {
            /// <inheritdoc cref="UserAuthenticatorsListRequest.ID" />
            public string? ID { get; private set; }

            /// <inheritdoc cref="UserAuthenticatorsListRequest.Email" />
            public string? Email { get; private set; }

            /// <inheritdoc cref="UserAuthenticatorsListRequest.Username" />
            public string? Username { get; private set; }

            /// <summary>
            /// Sets the id property.
            /// </summary>
            public Builder WithID(string id)
            {
                ID = id;
                return this;
            }

            /// <summary>
            /// Sets the email property.
            /// </summary>
            public Builder WithEmail(string email)
            {
                Email = email;
                return this;
            }

            /// <summary>Sets the username property.</summary>
            public Builder WithUsername(string username)
            {
                Username = username;
                return this;
            }

            /// <summary>
            /// Builds the <see cref="UserAuthenticatorsListRequest"/> instance.
            /// </summary>
            public UserAuthenticatorsListRequest Build()
            {
                return new UserAuthenticatorsListRequest(this);
            }
        }
    }
}

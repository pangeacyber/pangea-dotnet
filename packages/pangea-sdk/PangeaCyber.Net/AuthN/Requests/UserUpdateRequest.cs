using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserUpdateRequest : BaseRequest
    {
        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string? Email { get; private set; }

        /// <summary>The identity of a user or a service.</summary>
        [JsonProperty("id")]
        public string? ID { get; private set; }

        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string? Username { get; private set; }

        /// <summary>
        /// New disabled value. Disabling a user account will prevent them from logging in.
        /// </summary>
        [JsonProperty("disabled")]
        public bool? Disabled { get; private set; }

        /// <summary>
        /// Unlock a user account if it has been locked out due to failed authentication attempts.
        /// </summary>
        [JsonProperty("unlock")]
        public bool? Unlock { get; private set; }

        private UserUpdateRequest(Builder builder)
        {
            ID = builder.ID;
            Email = builder.Email;
            Username = builder.Username;
            Disabled = builder.Disabled;
            Unlock = builder.Unlock;
        }

        ///
        public class Builder
        {
            /// <inheritdoc cref="UserUpdateRequest.ID" />
            public string? ID { get; private set; }

            /// <inheritdoc cref="UserUpdateRequest.Email" />
            public string? Email { get; private set; }

            /// <inheritdoc cref="UserUpdateRequest.Username" />
            public string? Username { get; private set; }

            /// <inheritdoc cref="UserUpdateRequest.Disabled" />
            public bool? Disabled { get; private set; }

            /// <inheritdoc cref="UserUpdateRequest.Unlock" />
            public bool? Unlock { get; private set; }

            ///
            public Builder() { }

            ///
            public Builder WithId(string id)
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

            /// <summary>Add a username to the request.</summary>
            /// <param name="username">A username.</param>
            /// <returns>Builder.</returns>
            public Builder WithUsername(string username)
            {
                Username = username;
                return this;
            }

            ///
            public Builder WithDisabled(bool? disabled)
            {
                Disabled = disabled;
                return this;
            }

            ///
            public Builder WithUnlock(bool? unlock)
            {
                Unlock = unlock;
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

using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserProfileUpdateRequest : BaseRequest
    {
        /// <summary>Updates to a user profile.</summary>
        [JsonProperty("profile")]
        public Profile Profile { get; private set; }

        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string? Email { get; private set; }

        /// <summary>The identity of a user or a service.</summary>
        [JsonProperty("id")]
        public string? ID { get; private set; }

        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string? Username { get; private set; }

        ///
        private UserProfileUpdateRequest(Builder builder)
        {
            Profile = builder.Profile;
            Email = builder.Email;
            ID = builder.ID;
            Username = builder.Username;
        }

        ///
        public class Builder
        {
            /// <inheritdoc cref="UserProfileUpdateRequest.Profile" />
            public Profile Profile { get; private set; }

            /// <inheritdoc cref="UserProfileUpdateRequest.Email" />
            public string? Email { get; private set; }

            /// <inheritdoc cref="UserProfileUpdateRequest.ID" />
            public string? ID { get; private set; }

            /// <inheritdoc cref="UserProfileUpdateRequest.Username" />
            public string? Username { get; private set; }

            ///
            public Builder(Profile profile)
            {
                Profile = profile;
            }

            ///
            public Builder WithEmail(string email)
            {
                Email = email;
                return this;
            }

            ///
            public Builder WithID(string id)
            {
                ID = id;
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
            public UserProfileUpdateRequest Build()
            {
                return new UserProfileUpdateRequest(this);
            }
        }
    }
}

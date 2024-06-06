using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserCreateRequest : BaseRequest
    {
        /// <summary>An email address.</summary>
        [JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>A user profile as a collection of string properties.</summary>
        [JsonProperty("profile")]
        public Profile Profile { get; private set; }

        /// <summary>A username.</summary>
        [JsonProperty("username")]
        public string? Username { get; private set; }

        private UserCreateRequest(Builder builder)
        {
            Email = builder.Email;
            Profile = builder.Profile;
            Username = builder.Username;
        }

        ///
        public class Builder
        {
            /// <inheritdoc cref="UserCreateRequest.Email" />
            public string Email { get; private set; }

            /// <inheritdoc cref="UserCreateRequest.Profile" />
            public Profile Profile { get; private set; }

            /// <inheritdoc cref="UserCreateRequest.Username" />
            public string? Username { get; }

            ///
            public Builder(string email, Profile profile, string? username = null)
            {
                Email = email;
                Profile = profile;
                Username = username;
            }

            ///
            public UserCreateRequest Build()
            {
                return new UserCreateRequest(this);
            }
        }
    }
}

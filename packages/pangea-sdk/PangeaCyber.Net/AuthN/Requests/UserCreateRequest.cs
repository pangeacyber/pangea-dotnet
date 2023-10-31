using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserCreateRequest : BaseRequest
    {
        ///
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///
        [JsonProperty("profile")]
        public Profile Profile { get; private set; }

        private UserCreateRequest(Builder builder)
        {
            Email = builder.Email;
            Profile = builder.Profile;
        }

        ///
        public class Builder
        {
            ///
            public string Email { get; private set; }

            ///
            public Profile Profile { get; private set; }

            ///
            public Builder(string email, Profile profile)
            {
                Email = email;
                Profile = profile;
            }

            ///
            public UserCreateRequest Build()
            {
                return new UserCreateRequest(this);
            }
        }
    }
}

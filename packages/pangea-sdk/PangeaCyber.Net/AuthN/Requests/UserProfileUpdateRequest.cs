using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserProfileUpdateRequest : BaseRequest
    {
        ///
        [JsonProperty("profile")]
        public Profile Profile { get; private set; }

        ///
        [JsonProperty("email")]
        public string? Email { get; private set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; private set; }

        ///
        private UserProfileUpdateRequest(Builder builder)
        {
            this.Profile = builder.Profile;
            this.Email = builder.Email;
            this.ID = builder.ID;
        }

        ///
        public class Builder
        {
            ///
            public Profile Profile { get; private set; }
            ///
            public string? Email { get; private set; }
            ///
            public string? ID { get; private set; }

            ///
            public Builder(Profile profile)
            {
                this.Profile = profile;
            }

            ///
            public Builder WithEmail(string email)
            {
                this.Email = email;
                return this;
            }

            ///
            public Builder WithID(string id)
            {
                this.ID = id;
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

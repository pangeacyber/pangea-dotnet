using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    ///
    public class UserUpdateRequest : BaseRequest
    {
        ///
        [JsonProperty("email")]
        public string? Email { get; private set; }

        ///
        [JsonProperty("id")]
        public string? ID { get; private set; }

        ///
        [JsonProperty("disabled")]
        public bool? Disabled { get; private set; }

        private UserUpdateRequest(Builder builder)
        {
            ID = builder.ID;
            Email = builder.Email;
            Disabled = builder.Disabled;
        }

        ///
        public class Builder
        {
            ///
            public string? ID { get; private set; }
            ///
            public string? Email { get; private set; }
            ///
            public bool? Disabled { get; private set; }

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

            ///
            public Builder WithDisabled(bool? disabled)
            {
                Disabled = disabled;
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

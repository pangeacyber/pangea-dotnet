using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Requests
{
    /// <summary>
    ///
    /// </summary>
    public class UserAuthenticatorsListRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the id property.
        /// </summary>
        [JsonProperty("id")]
        public string? ID { get; private set; }

        /// <summary>
        /// Gets or sets the email property.
        /// </summary>
        [JsonProperty("email")]
        public string? Email { get; private set; }

        private UserAuthenticatorsListRequest(Builder builder)
        {
            ID = builder.ID;
            Email = builder.Email;
        }

        /// <summary>
        /// Builder class for <see cref="UserAuthenticatorsListRequest"/>.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Gets or sets the id property.
            /// </summary>
            public string? ID { get; private set; }

            /// <summary>
            /// Gets or sets the email property.
            /// </summary>
            public string? Email { get; private set; }

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

using Newtonsoft.Json;

namespace PangeaCyber.Net.Store.Models
{
    /// <summary>
    /// Represents an authenticator.
    /// </summary>
    public class Authenticator
    {
        /// <summary>
        /// Gets or sets the authenticator type.
        /// </summary>
        [JsonProperty("auth_type")]
        public AuthenticatorType AuthType { get; set; }

        /// <summary>
        /// Gets or sets the authenticator context.
        /// </summary>
        [JsonProperty("auth_context")]
        public string AuthContext { get; set; } = default!;

        ///
        public Authenticator(AuthenticatorType authType, string authContext)
        {
            AuthType = authType;
            AuthContext = authContext;
        }

    }
}

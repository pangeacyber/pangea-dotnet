using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    /// <summary>
    ///
    /// </summary>
    public class UserAuthenticatorsListResult
    {
        /// <summary>A list of authenticators.</summary>
        [JsonProperty("authenticators")]
        public Authenticator[] Authenticators { get; private set; } = default!;

        /// <summary>
        /// Default constructor for <see cref="UserAuthenticatorsListResult"/>.
        /// </summary>
        public UserAuthenticatorsListResult() { }
    }
}

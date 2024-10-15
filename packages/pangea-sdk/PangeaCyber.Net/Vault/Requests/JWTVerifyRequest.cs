using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class JWTVerifyRequest : BaseRequest
    {
        /// <summary>
        /// The signed JSON Web Token (JWS)
        /// </summary>
        [JsonProperty("jws")]
        public string JWS { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jws">The signed JSON Web Token (JWS)</param>
        public JWTVerifyRequest(string jws)
        {
            JWS = jws;
        }

    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SecretStoreRequest : CommonStoreRequest
    {
        /// <summary>
        /// The type of the secret
        /// </summary>
        [JsonProperty("type")]
        public ItemType Type { get; set; } = default!;

        /// <summary>
        /// The secret value
        /// </summary>
        [JsonProperty("secret")]
        public string? Secret { get; set; }

        /// <summary>
        /// The Pangea Token value
        /// </summary>
        [JsonProperty("token")]
        public string? Token { get; set; }

        /// <summary>
        /// The oauth client secret
        /// </summary>
        [JsonProperty("client_secret")]
        public string? ClientSecret { get; set; }

        /// <summary>
        /// The oauth client ID
        /// </summary>
        [JsonProperty("client_id")]
        public string? ClientID { get; set; }

        /// <summary>
        /// The oauth client secret ID
        /// </summary>
        [JsonProperty("client_secret_id")]
        public string? ClientSecretID { get; set; }

        /// <summary>
        /// Grace period for the previous version of the secret
        /// </summary>
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the item to store</param>
        public SecretStoreRequest(string name) : base(name) { }

        /// <summary>
        ///
        /// </summary>
        public SecretStoreRequest() : base("") { }
    }
}

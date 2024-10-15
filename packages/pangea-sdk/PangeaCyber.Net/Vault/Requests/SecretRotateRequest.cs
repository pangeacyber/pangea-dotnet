using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SecretRotateRequest : CommonRotateRequest
    {
        ///
        [JsonProperty("secret")]
        public string? Secret { get; set; }

        /// <summary>
        /// Grace period for the previous version of the secret
        /// </summary>
        [JsonProperty("rotation_grace_period")]
        public string? RotationGracePeriod { get; set; }

        ///
        public SecretRotateRequest(string id) : base(id) { }

    }
}

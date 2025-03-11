using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// VaultParameters
    /// </summary>
    public class VaultParameters
    {
        /// <summary>
        /// A vault key ID of an exportable key used to redact with FPE instead of using the service config default.
        /// </summary>
        [JsonProperty("fpe_key_id")]
        public string? FPEkeyID { get; set; }

        /// <summary>
        /// A vault secret ID of a secret used to salt a hash instead of using the service config default.
        /// </summary>
        [JsonProperty("salt_secret_id")]
        public string? SaltSecretID { get; set; }
    }
}

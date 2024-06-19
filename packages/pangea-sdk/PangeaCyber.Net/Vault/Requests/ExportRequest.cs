using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    /// <summary>Request parameters for exporting a key.</summary>
    public sealed class ExportRequest : BaseRequest
    {
        /// <summary>The ID of the key to use.</summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>The item version. Defaults to the current version.</summary>
        [JsonProperty("version")]
        public string? Version { get; set; }

        /// <summary>Public key in PEM format used to encrypt exported key(s).</summary>
        [JsonProperty("encryption_key")]
        public string? EncryptionKey { get; set; }

        /// <summary>The algorithm of the public key.</summary>
        [JsonProperty("encryption_algorithm")]
        public ExportEncryptionAlgorithm? EncryptionAlgorithm { get; set; }

        /// <summary>Constructor</summary>
        public ExportRequest(string id)
        {
            this.ID = id;
        }
    }
}

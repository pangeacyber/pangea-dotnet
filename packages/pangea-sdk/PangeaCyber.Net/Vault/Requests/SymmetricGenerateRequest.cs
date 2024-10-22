using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SymmetricGenerateRequest : CommonGenerateRequest
    {
        /// <summary>
        /// Item type
        /// </summary>
        [JsonProperty("type")]
        public ItemType Type { get; set; }

        /// <summary>
        /// The algorithm of the key
        /// </summary>
        [JsonProperty("algorithm")]
        public SymmetricAlgorithm Algorithm { get; set; }

        /// <summary>
        /// The purpose of the key
        /// </summary>
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="algorithm">The algorithm of the key</param>
        /// <param name="purpose">The purpose of the key</param>
        /// <param name="name">Name of the item</param>
        public SymmetricGenerateRequest(SymmetricAlgorithm algorithm, KeyPurpose purpose, string name) : base(name)
        {
            Type = ItemType.SymmetricKey;
            Algorithm = algorithm;
            Purpose = purpose;
        }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class AsymmetricGenerateRequest : CommonGenerateRequest
    {
        /// <summary>
        /// The type of the item
        /// </summary>
        [JsonProperty("type")]
        public ItemType Type { get; set; }

        /// <summary>
        /// The algorithm of the keys
        /// </summary>
        [JsonProperty("algorithm")]
        public AsymmetricAlgorithm Algorithm { get; set; }

        /// <summary>
        /// The purpose of the key
        /// </summary>
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="algorithm">The algorithm of the key to generate</param>
        /// <param name="purpose">The purpose of the key to generate</param>
        /// <param name="name">The name of the item to generate</param>
        public AsymmetricGenerateRequest(AsymmetricAlgorithm algorithm, KeyPurpose purpose, string name)
                : base(name)
        {
            Type = ItemType.AsymmetricKey;
            Algorithm = algorithm;
            Purpose = purpose;
        }

    }
}

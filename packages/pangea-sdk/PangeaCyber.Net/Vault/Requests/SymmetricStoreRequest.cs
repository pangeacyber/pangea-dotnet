using Newtonsoft.Json;
using PangeaCyber.Net.Vault.Models;

namespace PangeaCyber.Net.Vault.Requests
{
    ///
    public class SymmetricStoreRequest : CommonStoreRequest
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
        /// Key material to be stored
        /// </summary>
        [JsonProperty("key")]
        public string EncodedSymmetricKey { get; set; }

        /// <summary>
        /// The purpose of the key
        /// </summary>
        [JsonProperty("purpose")]
        public KeyPurpose Purpose { get; set; }

        /// <summary>Whether the key is exportable or not.</summary>
        [JsonProperty("exportable")]
        public bool Exportable { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="encodedSymmetricKey">Key material to be stored</param>
        /// <param name="algorithm">The algorithm of the key</param>
        /// <param name="purpose">The purpose of the key</param>
        /// <param name="name">Name of the item</param>
        public SymmetricStoreRequest(string encodedSymmetricKey, SymmetricAlgorithm algorithm, KeyPurpose purpose, string name) : base(name)
        {
            Type = ItemType.SymmetricKey;
            Algorithm = algorithm;
            EncodedSymmetricKey = encodedSymmetricKey;
            Purpose = purpose;
        }
    }
}

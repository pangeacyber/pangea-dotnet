using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    /// <summary>
    /// Result of an encrypt/decrypt structured request.
    /// </summary>
    /// <typeparam name="T">Structured data type.</typeparam>
    public sealed class EncryptStructuredResult<T> : BaseRequest
    {
        /// <summary>The ID of the item.</summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        /// <summary>The item version.</summary>
        [JsonProperty("version")]
        public int Version { get; set; } = default!;

        /// <summary>The algorithm of the key.</summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = default!;

        /// <summary>Structured data with filtered fields encrypted.</summary>
        [JsonProperty("structured_data")]
        public T StructuredData { get; set; } = default!;
    }
}

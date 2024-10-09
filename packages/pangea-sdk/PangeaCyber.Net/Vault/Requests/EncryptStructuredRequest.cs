using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Requests
{
    /// <summary>
    /// Parameters for an encrypt/decrypt structured request.
    /// </summary>
    /// <typeparam name="T">Structured data type.</typeparam>
    public sealed class EncryptStructuredRequest<T> : BaseRequest
    {
        /// <summary>
        /// The ID of the key to use. It must be an item of type `symmetric_key` or `asymmetric_key` and purpose
        /// `encryption`.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>Structured data for applying bulk operations.</summary>
        [JsonProperty("structured_data")]
        public T StructuredData { get; set; }

        /// <summary>A filter expression. It must point to string elements of the `structured_data` field.</summary>
        [JsonProperty("filter")]
        public string Filter { get; set; }

        /// <summary>The item version. Defaults to the current version.</summary>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>User provided authentication data.</summary>
        [JsonProperty("additional_data")]
        public string? AdditionalData { get; set; }

        /// <summary>Constructor.</summary>
        /// <param name="id">
        /// The ID of the key to use. It must be an item of type `symmetric_key` or `asymmetric_key` and purpose
        /// `encryption`.
        /// </param>
        /// <param name="structuredData">Structured data for applying bulk operations.</param>
        /// <param name="filter">
        /// A filter expression. It must point to string elements of the `structured_data` field.
        /// </param>
        public EncryptStructuredRequest(string id, T structuredData, string filter)
        {
            this.ID = id;
            this.StructuredData = structuredData;
            this.Filter = filter;
        }

    }
}

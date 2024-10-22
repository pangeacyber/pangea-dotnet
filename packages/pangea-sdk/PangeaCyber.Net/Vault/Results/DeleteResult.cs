using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class DeleteResult
    {
        /// <summary>
        /// The item ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = default!;
    }
}

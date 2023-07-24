using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
{
    ///
    public class DeleteResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        public DeleteResult()
        {
        }
    }
}

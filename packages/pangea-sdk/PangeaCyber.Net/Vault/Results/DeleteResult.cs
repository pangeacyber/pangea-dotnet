using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
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

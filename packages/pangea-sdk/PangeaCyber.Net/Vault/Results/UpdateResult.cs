using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class UpdateResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        public UpdateResult()
        {
        }

    }
}

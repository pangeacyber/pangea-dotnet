using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault.Results
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

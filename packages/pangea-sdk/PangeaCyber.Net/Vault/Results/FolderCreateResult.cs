using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class FolderCreateResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        public FolderCreateResult()
        {
        }
    }
}

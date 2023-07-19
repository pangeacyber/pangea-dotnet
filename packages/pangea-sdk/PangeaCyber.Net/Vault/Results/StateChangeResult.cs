using Newtonsoft.Json;

namespace PangeaCyber.Net.Vault
{
    ///
    public class StateChangeResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("state")]
        public string State { get; set; } = default!;

        ///
        [JsonProperty("version")]
        public int Version { get; set; }

        ///
        [JsonProperty("destroy_at")]
        public string DestroyAt { get; set; } = default!;

        ///
        public StateChangeResult()
        {
        }

    }
}

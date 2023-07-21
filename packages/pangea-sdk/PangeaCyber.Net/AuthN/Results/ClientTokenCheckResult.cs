using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class ClientTokenCheckResult
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; } = default!;

        ///
        [JsonProperty("type")]
        public string Type { get; private set; } = default!;

        ///
        [JsonProperty("life")]
        public int Life { get; private set; }

        ///
        [JsonProperty("expire")]
        public string Expire { get; private set; } = default!;

        ///
        [JsonProperty("identity")]
        public string Identity { get; private set; } = default!;

        ///
        [JsonProperty("email")]
        public string Email { get; private set; } = default!;

        ///
        [JsonProperty("scopes")]
        public Scopes? Scopes { get; private set; }

        ///
        [JsonProperty("profile")]
        public Profile? Profile { get; private set; }

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; } = default!;

        ///
        public ClientTokenCheckResult() { }
    }
}

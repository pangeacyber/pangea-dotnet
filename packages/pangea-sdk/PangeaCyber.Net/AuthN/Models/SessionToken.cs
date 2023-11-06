using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class SessionToken
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
        public string? Expire { get; private set; }

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
        [JsonProperty("intelligence")]
        public Intelligence Intelligence { get; private set; } = default!;
    }
}

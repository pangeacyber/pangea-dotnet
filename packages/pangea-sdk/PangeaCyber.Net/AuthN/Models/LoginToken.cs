using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class LoginToken
    {
        ///
        [JsonProperty("token")]
        public string Token { get; set; } = default!;

        ///
        [JsonProperty("id")]
        public string ID { get; set; } = default!;

        ///
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        ///
        [JsonProperty("life")]
        public int? Life { get; set; }

        ///
        [JsonProperty("expire")]
        public string? Expire { get; set; }

        ///
        [JsonProperty("identity")]
        public string Identity { get; set; } = default!;

        ///
        [JsonProperty("email")]
        public string Email { get; set; } = default!;

        ///
        [JsonProperty("profile")]
        public Profile? Profile { get; set; }

        ///
        [JsonProperty("scopes")]
        public Scopes? Scopes { get; set; }

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = default!;
    }
}

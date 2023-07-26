using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class JWK
    {
        ///
        [JsonProperty("alg")]
        public string Alg { get; set; } = default!;

        ///
        [JsonProperty("kty")]
        public string Kty { get; set; } = default!;

        ///
        [JsonProperty("kid")]
        public string Kid { get; set; } = default!;

        ///
        [JsonProperty("use")]
        public string? Use { get; set; }

        ///
        [JsonProperty("crv")]
        public string? Crv { get; set; }

        ///
        [JsonProperty("d")]
        public string? D { get; set; }

        ///
        [JsonProperty("x")]
        public string? X { get; set; }

        ///
        [JsonProperty("y")]
        public string? Y { get; set; }

        ///
        [JsonProperty("n")]
        public string? N { get; set; }

        ///
        [JsonProperty("e")]
        public string? E { get; set; }
    }
}

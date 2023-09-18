using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class AgreementInfo
    {
        ///
        [JsonProperty("type")]
        public string Type { get; private set; } = default!;

        ///
        [JsonProperty("id")]
        public string ID { get; private set; } = default!;

        ///
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; } = default!;

        ///
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; } = default!;

        ///
        [JsonProperty("published_at")]
        public string? PublishedAt { get; private set; }

        ///
        [JsonProperty("name")]
        public string Name { get; private set; } = default!;

        ///
        [JsonProperty("text")]
        public string Text { get; private set; } = default!;

        ///
        [JsonProperty("active")]
        public bool Active { get; private set; }
    }
}

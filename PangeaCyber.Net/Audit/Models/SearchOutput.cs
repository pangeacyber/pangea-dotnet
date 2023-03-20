using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// SearchOutput
    /// </summary>
    public class SearchOutput : ResultsOutput
    {
        ///
        [JsonProperty("id")]
        public string ID { get; private set; } = default!;

        ///
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; private set; } = default!;
    }
}

using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// ResultsOutput
    /// </summary>
    public class ResultsOutput
    {
        ///
        [JsonProperty("count", Required = Required.Always)]
        public int Count { get; private set; } = default!;

        ///
        [JsonProperty("events", Required = Required.Always)]
        public SearchEvent[] Events { get; private set; } = default!;

        ///
        [JsonProperty("root")]
        public Root Root { get; private set; } = default!;

        ///
        [JsonProperty("unpublished_root")]
        public Root UnpublishedRoot { get; private set; } = default!;
    }
}

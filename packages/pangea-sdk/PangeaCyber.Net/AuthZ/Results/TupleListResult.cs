using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthZ.Results
{
    /// <kind>class</kind>
    /// <summary>
    /// TupleListResult
    /// </summary>
    public sealed class TupleListResult
    {
        ///
        [JsonProperty("tuples")]
        public Models.Tuple[] Tuples { get; private set; } = { };

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; } = default!;

        ///
        [JsonProperty("count")]
        public int Count { get; private set; } = default!;

    }
}

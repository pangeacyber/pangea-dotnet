
using Newtonsoft.Json;
using PangeaCyber.Net.AuthZ.Models;

namespace PangeaCyber.Net.AuthZ.Results
{
    /// <kind>class</kind>
    /// <summary>
    /// CheckResult
    /// </summary>
    public sealed class CheckResult
    {
        ///
        [JsonProperty("schema_id")]
        public string SchemaID { get; private set; } = default!;

        ///
        [JsonProperty("schema_version")]
        public int SchemaVersion { get; private set; } = default!;

        ///
        [JsonProperty("depth")]
        public int Depth { get; private set; } = default!;

        ///
        [JsonProperty("allowed")]
        public bool Allowed { get; private set; } = default!;

        ///
        [JsonProperty("debug")]
        public Debug? Debug { get; private set; } = default!;
    }

}

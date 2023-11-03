using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// LogResult
    /// </summary>
    public sealed class LogBulkResult
    {
        ///
        [JsonProperty("results")]
        public LogResult[] Results { get; private set; } = default!;

    }
}

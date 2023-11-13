using Newtonsoft.Json;

namespace PangeaCyber.Net.Audit
{
    /// <kind>class</kind>
    /// <summary>
    /// LogRequest
    /// </summary>
    public class LogBulkRequest : BaseRequest
    {
        ///
        [JsonProperty("events", Required = Required.Always)]
        public LogEvent[] Events { get; set; } = default!;

        ///
        [JsonProperty("verbose")]
        public bool? Verbose { get; set; } = null;

        ///
        public LogBulkRequest(LogEvent[] events, bool? verbose)
        {
            Events = events;
            Verbose = verbose;
        }
    }
}

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
        public bool Verbose { get; set; } = default!;

        ///
        [JsonProperty("prev_root")]
        public string PrevRoot { get; set; } = default!;

        ///
        public LogBulkRequest(LogEvent[] events, bool verbose, string prevRoot)
        {
            Events = events;
            Verbose = verbose;
            PrevRoot = prevRoot;
        }
    }
}

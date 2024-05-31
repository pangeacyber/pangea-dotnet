using Newtonsoft.Json;

namespace PangeaCyber.Net.Redact
{
    /// <kind>class</kind>
    /// <summary>
    /// RedactTextResult
    /// </summary>
    public sealed class UnredactResult
    {
        ///
        [JsonProperty("data")]
        public object data { get; private set; } = default!;
    }
}

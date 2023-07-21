using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class SessionListResult
    {
        ///
        [JsonProperty("sessions")]
        public SessionItem[] Sessions { get; private set; } = default!;

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        public SessionListResult(){}

    }
}

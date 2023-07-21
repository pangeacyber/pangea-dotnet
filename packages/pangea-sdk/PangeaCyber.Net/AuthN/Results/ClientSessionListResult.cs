using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class ClientSessionListResult
    {
        ///
        [JsonProperty("sessions")]
        public SessionItem[] Sessions { get; private set; } = default!;

        ///
        [JsonProperty("last")]
        public string? Last { get; private set; }

        ///
        public ClientSessionListResult() { }

    }
}

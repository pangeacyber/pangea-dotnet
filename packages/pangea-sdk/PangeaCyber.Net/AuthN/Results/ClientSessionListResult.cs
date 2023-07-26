using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
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

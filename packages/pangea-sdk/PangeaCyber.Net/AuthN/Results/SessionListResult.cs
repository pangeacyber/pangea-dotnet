using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
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

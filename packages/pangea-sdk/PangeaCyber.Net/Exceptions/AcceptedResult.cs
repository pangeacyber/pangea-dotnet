using Newtonsoft.Json;

namespace PangeaCyber.Net.Exceptions
{
    ///
    public class AcceptedResult
    {
        ///
        [JsonProperty("accepted_status")]
        public AcceptedStatus AcceptedStatus { get; private set; } = new AcceptedStatus();

        ///
        public AcceptedResult() { }

    }
}

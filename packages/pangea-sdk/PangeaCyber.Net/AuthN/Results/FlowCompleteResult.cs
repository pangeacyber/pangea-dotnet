using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    ///
    public class FlowCompleteResult
    {
        ///
        [JsonProperty("active_token")]
        public LoginToken? ActiveToken { get; private set; }

        ///
        [JsonProperty("refresh_token")]
        public LoginToken RefreshToken { get; private set; } = default!;

        ///
        public FlowCompleteResult() { }
    }
}

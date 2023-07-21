using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class FlowCompleteResult
    {
        ///
        [JsonProperty("active_token")]
        public LoginToken? LoginToken { get; private set; }

        ///
        [JsonProperty("refresh_token")]
        public LoginToken? RefreshToken { get; private set; }

        ///
        public FlowCompleteResult() {}
    }
}

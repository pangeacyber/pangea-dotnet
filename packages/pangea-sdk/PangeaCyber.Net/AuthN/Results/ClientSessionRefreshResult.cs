using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    ///
    public class ClientSessionRefreshResult
    {
        ///
        [JsonProperty("refresh_token")]
        public LoginToken RefreshToken { get; private set; } = default!;

        ///
        [JsonProperty("active_token")]
        public LoginToken? ActiveToken { get; private set; }

        ///
        public ClientSessionRefreshResult() { }
    }
}

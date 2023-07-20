using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class SocialSignup
    {
        ///
        [JsonProperty("redirect_uri")]
        public Dictionary<string, string>? RedirectURI { get; set; }
    }
}

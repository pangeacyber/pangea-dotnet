using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class VerifySocial
    {
        ///
        [JsonProperty("redirect_uri")]
        public string RedirectURI { get; set; } = default!;
    }
}

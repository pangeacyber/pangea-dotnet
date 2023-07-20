using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class VerifyCaptcha
    {
        ///
        [JsonProperty("site_key")]
        public string SiteKey { get; set; } = default!;
    }
}

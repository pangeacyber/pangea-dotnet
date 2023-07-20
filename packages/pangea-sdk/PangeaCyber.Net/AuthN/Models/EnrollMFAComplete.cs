using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class EnrollMFAComplete
    {
        ///
        [JsonProperty("totp_secret")]
        public TOTPsecret TOTPSecret { get; set; } = new TOTPsecret();
    }

}

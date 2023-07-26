using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class EnrollMFAComplete
    {
        ///
        [JsonProperty("totp_secret")]
        public TOTPsecret TOTPSecret { get; set; } = new TOTPsecret();
    }

}

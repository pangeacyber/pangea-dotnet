using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class TOTPsecret
    {
        ///
        [JsonProperty("qr_image")]
        public string? QrImage { get; set; }

        ///
        [JsonProperty("secret")]
        public string Secret { get; set; } = default!;
    }
}

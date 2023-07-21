using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class VerifyMFAStart
    {
        ///
        [JsonProperty("mfa_providers")]
        public string[] MFAProviders { get; set; } = default!;
    }
}

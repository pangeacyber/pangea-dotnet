using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class VerifyMFAStart
    {
        ///
        [JsonProperty("mfa_providers")]
        public string[] MfaProviders { get; set; } = default!;
    }
}

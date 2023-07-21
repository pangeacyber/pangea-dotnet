using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class VerifyMFAStart
    {
        ///
        [JsonProperty("mfa_providers")]
        public string[] MFAProviders { get; set; } = default!;
    }
}

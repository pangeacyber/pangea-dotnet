using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class EnrollMFAStart
    {
        ///
        [JsonProperty("mfa_providers")]
        public MFAProviders? MFAProviders { get; set; }
    }
}

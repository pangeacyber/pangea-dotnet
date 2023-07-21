using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class EnrollMFAStart
    {
        ///
        [JsonProperty("mfa_providers")]
        public MFAProviders? MFAProviders { get; set; }
    }
}

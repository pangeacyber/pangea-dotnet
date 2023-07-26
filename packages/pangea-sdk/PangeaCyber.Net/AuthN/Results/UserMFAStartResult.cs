using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    ///
    public class UserMFAStartResult : CommonFlowResult
    {
        ///
        [JsonProperty("totp_secret")]
        public TOTPsecret? TotpSecret { get; private set; }

        ///
        public UserMFAStartResult() { }
    }
}

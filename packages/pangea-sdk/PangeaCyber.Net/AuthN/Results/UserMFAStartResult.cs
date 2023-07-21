using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN
{
    ///
    public class UserMFAStartResult : CommonFlowResult
    {
        ///
        [JsonProperty("totp_secret")]
        public TOTPsecret? TotpSecret { get; private set; }

        ///
        public UserMFAStartResult(){}
    }
}

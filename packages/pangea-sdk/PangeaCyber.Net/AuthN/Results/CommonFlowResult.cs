using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Models;

namespace PangeaCyber.Net.AuthN.Results
{
    ///
    public class CommonFlowResult
    {
        ///
        [JsonProperty("flow_id")]
        public string? FlowID { get; private set; }

        ///
        [JsonProperty("next_step")]
        public string? NextStep { get; private set; }

        ///
        [JsonProperty("error")]
        public string? Error { get; private set; }

        ///
        [JsonProperty("complete")]
        public Dictionary<string, object>? Complete { get; private set; }

        ///
        [JsonProperty("enroll_mfa_start")]
        public EnrollMFAStart? EnrollMFAStart { get; private set; }

        ///
        [JsonProperty("enroll_mfa_complete")]
        public EnrollMFAComplete? EnrollMFAComplete { get; private set; }

        ///
        [JsonProperty("signup")]
        public Signup? Signup { get; private set; }

        ///
        [JsonProperty("verify_captcha")]
        public VerifyCaptcha? VerifyCaptcha { get; private set; }

        ///
        [JsonProperty("verify_email")]
        public Dictionary<string, object>? VerifyEmail { get; private set; }

        ///
        [JsonProperty("verify_mfa_start")]
        public VerifyMFAStart? VerifyMFAStart { get; private set; }

        ///
        [JsonProperty("verify_mfa_complete")]
        public Dictionary<string, object>? VerifyMFAComplete { get; private set; }

        ///
        [JsonProperty("verify_password")]
        public VerifyPassword? VerifyPassword { get; private set; }

        ///
        [JsonProperty("verify_social")]
        public VerifySocial? VerifySocial { get; private set; }

        ///
        [JsonProperty("reset_password")]
        public VerifyPassword? ResetPassword { get; private set; }
    }
}

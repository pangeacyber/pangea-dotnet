using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowVerify : AuthNBaseClient
    {
        ///
        public FlowVerifyMFA MFA { get; private set; }

        ///
        public FlowVerify(AuthNClient.Builder builder) : base(builder)
        {
            MFA = new FlowVerifyMFA(builder);
        }

        // TODO: doc
        ///
        public async Task<Response<FlowVerifyCaptchaResult>> Captcha(string flowId, string code)
        {
            var request = new FlowVerifyCaptchaRequest(flowId, code);
            return await DoPost<FlowVerifyCaptchaResult>("/v1/flow/verify/captcha", request);
        }

        // TODO: doc
        ///
        public async Task<Response<FlowVerifyEmailResult>> Email(FlowVerifyEmailRequest request)
        {
            return await DoPost<FlowVerifyEmailResult>("/v1/flow/verify/email", request);
        }

        // TODO: doc
        ///
        public async Task<Response<FlowVerifyPasswordResult>> Password(FlowVerifyPasswordRequest request)
        {
            return await DoPost<FlowVerifyPasswordResult>("/v1/flow/verify/password", request);
        }

        // TODO: doc
        ///
        public async Task<Response<FlowVerifySocialResult>> Social(FlowVerifySocialRequest request)
        {
            return await DoPost<FlowVerifySocialResult>("/v1/flow/verify/social", request);
        }

        internal class FlowVerifyCaptchaRequest : BaseRequest
        {
            [JsonProperty("flow_id")]
            public string FlowID { get; private set; }

            [JsonProperty("code")]
            public string Code { get; private set; }

            public FlowVerifyCaptchaRequest(string flowID, string code)
            {
                FlowID = flowID;
                Code = code;
            }
        }

    }
}

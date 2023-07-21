using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowVerifyMFA : AuthNBaseClient
    {
        ///
        public FlowVerifyMFA(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<FlowVerifyMFACompleteResult>> Complete(FlowVerifyMFACompleteRequest request)
        {
            return await DoPost<FlowVerifyMFACompleteResult>("/v1/flow/verify/mfa/complete", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<FlowVerifyMFAStartResult>> Start(string flowID, MFAProvider mfaProvider)
        {
            var request = new FlowVerifyMFAStartRequest(flowID, mfaProvider);
            return await DoPost<FlowVerifyMFAStartResult>("/v1/flow/verify/mfa/start", request);
        }

        internal class FlowVerifyMFAStartRequest : BaseRequest
        {
            [JsonProperty("flow_id")]
            public string FlowID { get; private set; }

            [JsonProperty("mfa_provider")]
            public MFAProvider MFAProvider { get; private set; }

            public FlowVerifyMFAStartRequest(string flowID, MFAProvider mfaProvider)
            {
                FlowID = flowID;
                MFAProvider = mfaProvider;
            }
        }
    }
}

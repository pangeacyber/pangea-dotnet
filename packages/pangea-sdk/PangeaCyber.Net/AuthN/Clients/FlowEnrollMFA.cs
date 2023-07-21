using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowEnrollMFA : AuthNBaseClient
    {
        ///
        public FlowEnrollMFA(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<FlowEnrollMFACompleteResult>> Complete(FlowVerifyMFACompleteRequest request)
        {
            return await DoPost<FlowEnrollMFACompleteResult>("/v1/flow/enroll/mfa/complete", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<FlowEnrollMFAStartResult>> Start(string flowID, MFAProvider mfaProvider)
        {
            var request = new FlowEnrollMFAStartRequest(flowID, mfaProvider);
            return await DoPost<FlowEnrollMFAStartResult>("/v1/flow/enroll/mfa/start", request);
        }

        internal class FlowEnrollMFAStartRequest : BaseRequest
        {
            [JsonProperty("flow_id")]
            public string FlowID { get; private set; }

            [JsonProperty("mfa_provider")]
            public MFAProvider MFAProvider { get; private set; }

            public FlowEnrollMFAStartRequest(string flowID, MFAProvider mfaProvider)
            {
                FlowID = flowID;
                MFAProvider = mfaProvider;
            }
        }
    }
}

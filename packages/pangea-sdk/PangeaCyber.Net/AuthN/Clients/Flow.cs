using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class Flow : AuthNBaseClient
    {
        ///
        public FlowEnroll Enroll { get; private set; }
        ///
        public FlowSignup Signup { get; private set; }
        ///
        public FlowVerify Verify { get; private set; }
        ///
        public FlowReset Reset { get; private set; }

        ///
        public Flow(AuthNClient.Builder builder) : base(builder)
        {
            Enroll = new FlowEnroll(builder);
            Signup = new FlowSignup(builder);
            Verify = new FlowVerify(builder);
            Reset = new FlowReset(builder);
        }

        ///
        public async Task<Response<FlowCompleteResult>> Complete(string flowID)
        {
            FlowCompleteRequest request = new FlowCompleteRequest(flowID);
            return await DoPost<FlowCompleteResult>("/v1/flow/complete", request);
        }

        ///
        public async Task<Response<FlowStartResult>> Start(FlowStartRequest request)
        {
            return await DoPost<FlowStartResult>("/v1/flow/start", request);
        }

        internal class FlowCompleteRequest : BaseRequest
        {
            ///
            [JsonProperty("flow_id")]
            public string FlowID { get; private set; }

            ///
            public FlowCompleteRequest(string flowID)
            {
                FlowID = flowID;
            }
        }
    }
}

using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class Flow : AuthNBaseClient
    {

        ///
        public Flow(AuthNClient.Builder builder) : base(builder)
        {
        }

        ///
        public async Task<Response<FlowCompleteResult>> Complete(string flowID)
        {
            FlowCompleteRequest request = new FlowCompleteRequest(flowID);
            return await DoPost<FlowCompleteResult>("/v2/flow/complete", request);
        }

        ///
        public async Task<Response<FlowStartResult>> Start(FlowStartRequest request)
        {
            return await DoPost<FlowStartResult>("/v2/flow/start", request);
        }

        ///
        public async Task<Response<FlowUpdateResult>> Update(FlowUpdateRequest request)
        {
            return await DoPost<FlowUpdateResult>("/v2/flow/update", request);
        }

        ///
        public async Task<Response<FlowRestartResult>> Restart(FlowRestartRequest request)
        {
            return await DoPost<FlowRestartResult>("/v2/flow/restart", request);
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

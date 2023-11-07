using Newtonsoft.Json;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    /// <kind>class</kind>
    /// <summary>
    /// AuthN Client
    /// </summary>
    public class Flow : AuthNBaseClient
    {

        ///
        public Flow(AuthNClient.Builder builder) : base(builder)
        {
        }

        /// <kind>method</kind>
        /// <summary>Complete a sign-up or sign-in flow.</summary>
        /// <remarks>Complete sign-up/sign-in</remarks>
        /// <operationid>authn_post_v2_flow_complete</operationid>
        /// <param name="flowID" type="string">An ID for a login or signup flow</param>
        /// <returns>Response&lt;FlowCompleteResult&gt;</returns>
        /// <example>
        /// <code>
        /// var response = await client.Flow.Complete("pfl_dxiqyuq7ndc5ycjwdgmguwuodizcaqhh");
        /// </code>
        /// </example>
        public async Task<Response<FlowCompleteResult>> Complete(string flowID)
        {
            FlowCompleteRequest request = new FlowCompleteRequest(flowID);
            return await DoPost<FlowCompleteResult>("/v2/flow/complete", request);
        }

        /// <kind>method</kind>
        /// <summary>Start a new sign-up or sign-in flow.</summary>
        /// <remarks>Start a sign-up/sign-in flow</remarks>
        /// <operationid>authn_post_v2_flow_start</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.FlowStartRequest"></param>
        /// <returns>Response&lt;FlowStartResult&gt;</returns>
        /// <example>
        /// <code>
        /// FlowType[] flowType = { FlowType.Signin, FlowType.Signup };
        /// var request = new FlowStartRequest
        ///     .Builder()
        ///     .WithEmail("joe.user@email.com")
        ///     .WithCBUri("https://www.myserver.com/callback")
        ///     .WithFlowType(flowType)
        ///     .WithInvitation("pmc_wuk7tvtpswyjtlsx52b7yyi2l7zotv4a")
        ///     .Build();
        /// 
        /// var response = await client.Flow.Start(request);
        /// </code>
        /// </example>
        public async Task<Response<FlowStartResult>> Start(FlowStartRequest request)
        {
            return await DoPost<FlowStartResult>("/v2/flow/start", request);
        }

        /// <kind>method</kind>
        /// <summary>Update a sign-up/sign-in flow.</summary>
        /// <remarks>Update a sign-up/sign-in flow</remarks>
        /// <operationid>authn_post_v2_flow_update</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.FlowUpdateRequest"></param>
        /// <returns>Response&lt;FlowUpdateResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
        public async Task<Response<FlowUpdateResult>> Update(FlowUpdateRequest request)
        {
            return await DoPost<FlowUpdateResult>("/v2/flow/update", request);
        }

        /// <kind>method</kind>
        /// <summary>Restart a sign-up/sign-in flow choice.</summary>
        /// <remarks>Restart a sign-up/sign-in flow</remarks>
        /// <operationid>authn_post_v2_flow_restart</operationid>
        /// <param name="request" type="PangeaCyber.Net.AuthN.Requests.FlowRestartRequest"></param>
        /// <returns>Response&lt;FlowRestartResult&gt;</returns>
        /// <example>
        /// <code>
        /// </code>
        /// </example>
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

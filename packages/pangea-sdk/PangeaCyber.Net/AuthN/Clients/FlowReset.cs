using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowReset : AuthNBaseClient
    {
        ///
        public FlowReset(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<FlowResetPasswordResult>> Password(FlowResetPasswordRequest request)
        {
            return await DoPost<FlowResetPasswordResult>("/v1/flow/reset/password", request);
        }
    }
}

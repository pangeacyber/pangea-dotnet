using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class FlowSignup : AuthNBaseClient
    {
        ///
        public FlowSignup(AuthNClient.Builder builder) : base(builder) { }

        // TODO: doc
        ///
        public async Task<Response<FlowSignupPasswordResult>> Password(string flow_id, string password, string firstName, string lastName)
        {
            var request = new FlowSignupPasswordRequest(flow_id, password, firstName, lastName);
            return await DoPost<FlowSignupPasswordResult>("/v1/flow/signup/password", request);
        }

        // TODO: doc
        ///
        public async Task<Response<FlowSignupPasswordResult>> Social(string flow_id, string cbState, string cbCode)
        {
            var request = new FlowSignupSocialRequest(flow_id, cbState, cbCode);
            return await DoPost<FlowSignupPasswordResult>("/v1/flow/signup/social", request);
        }

        internal class FlowSignupPasswordRequest : BaseRequest
        {
            [JsonProperty("flow_id")]
            public string FlowId { get; private set; }

            [JsonProperty("password")]
            public string Password { get; private set; }

            [JsonProperty("first_name")]
            public string FirstName { get; private set; }

            [JsonProperty("last_name")]
            public string LastName { get; private set; }

            public FlowSignupPasswordRequest(string flow_id, string password, string firstName, string lastName)
            {
                FlowId = flow_id;
                Password = password;
                FirstName = firstName;
                LastName = lastName;
            }
        }

        internal class FlowSignupSocialRequest : BaseRequest
        {
            [JsonProperty("flow_id")]
            public string FlowId { get; private set; }

            [JsonProperty("cb_state")]
            public string CbState { get; private set; }

            [JsonProperty("cb_code")]
            public string CbCode { get; private set; }

            public FlowSignupSocialRequest(string flow_id, string cbState, string cbCode)
            {
                FlowId = flow_id;
                CbState = cbState;
                CbCode = cbCode;
            }
        }
    }
}

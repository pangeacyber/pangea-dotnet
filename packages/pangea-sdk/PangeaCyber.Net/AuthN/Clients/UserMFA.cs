using PangeaCyber.Net.AuthN.Models;
using PangeaCyber.Net.AuthN.Requests;
using PangeaCyber.Net.AuthN.Results;
using Newtonsoft.Json;

namespace PangeaCyber.Net.AuthN.Clients
{
    ///
    public class UserMFA : AuthNBaseClient
    {
        ///
        public UserMFA(AuthNClient.Builder builder) : base(builder) { }

        // TODO: Doc
        ///
        public async Task<Response<UserMFADeleteResult>> Delete(string userID, MFAProvider mfaProvider)
        {
            var request = new UserMFADeleteRequest(userID, mfaProvider);
            return await DoPost<UserMFADeleteResult>("/v1/user/mfa/delete", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserMFAEnrollResult>> Enroll(string userID, MFAProvider mfaProvider, string code)
        {
            var request = new UserMFAEnrollRequest(userID, mfaProvider, code);
            return await DoPost<UserMFAEnrollResult>("/v1/user/mfa/enroll", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserMFAStartResult>> Start(UserMFAStartRequest request)
        {
            return await DoPost<UserMFAStartResult>("/v1/user/mfa/start", request);
        }

        // TODO: Doc
        ///
        public async Task<Response<UserMFAVerifyResult>> Verify(string userID, MFAProvider mfaProvider, string code)
        {
            var request = new UserMFAVerifyRequest(userID, mfaProvider, code);
            return await DoPost<UserMFAVerifyResult>("/v1/user/mfa/verify", request);
        }

        internal sealed class UserMFADeleteRequest : BaseRequest
        {
            [JsonProperty("user_id")]
            public string UserID { get; private set; }

            [JsonProperty("mfa_provider")]
            public MFAProvider MFAProvider { get; private set; }

            public UserMFADeleteRequest(string userID, MFAProvider mfaProvider)
            {
                UserID = userID;
                MFAProvider = mfaProvider;
            }
        }

        internal sealed class UserMFAEnrollRequest : BaseRequest
        {
            [JsonProperty("user_id")]
            public string UserID { get; private set; }

            [JsonProperty("mfa_provider")]
            public MFAProvider MFAProvider { get; private set; }

            [JsonProperty("code")]
            public string Code { get; private set; }

            public UserMFAEnrollRequest(string userID, MFAProvider mfaProvider, string code)
            {
                UserID = userID;
                MFAProvider = mfaProvider;
                Code = code;
            }
        }

        internal sealed class UserMFAVerifyRequest : BaseRequest
        {
            [JsonProperty("user_id")]
            public string UserID { get; private set; }

            [JsonProperty("mfa_provider")]
            public MFAProvider MFAProvider { get; private set; }

            [JsonProperty("code")]
            public string Code { get; private set; }

            public UserMFAVerifyRequest(string userID, MFAProvider mfaProvider, string code)
            {
                UserID = userID;
                MFAProvider = mfaProvider;
                Code = code;
            }
        }
    }
}
